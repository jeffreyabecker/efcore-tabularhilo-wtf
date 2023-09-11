using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace ConsoleApp2.HiLo.Metadata.Conventions;
public class SequenceTableConvention :  IModelFinalizingConvention
{
    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        var entityName = typeof(SequenceTable).FullName;
        var sequencesTableName = (string?)modelBuilder.Metadata.FindAnnotation(AnnotationNames.SequenceTableName)?.Value ?? SequenceTable.DefaultTableName;
        if(!modelBuilder.Metadata.GetEntityTypes().Any(e=>e.Name == entityName))
        {
            var sequencesEntity = modelBuilder.Entity(entityName);

            sequencesEntity.Property(typeof(string), nameof(SequenceTable.SequenceName))
                .IsRequired(true)
                .HasMaxLength(255);
            sequencesEntity.Property(typeof(long), nameof(SequenceTable.CurrentValue))
                .IsRequired(true);
            sequencesEntity.Property(typeof(long), nameof(SequenceTable.IncrementBy))
                .IsRequired(true);
            sequencesEntity.PrimaryKey(new List<string> { nameof(SequenceTable.SequenceName) }, false);
            sequencesEntity.ToTable(sequencesTableName);

            var sequences = modelBuilder.Metadata.GetEntityTypes()
                .Where(HasHiLoSequence)
                .Select(GetSequenceInfo)
                .ToList();
            var entityType = (IMutableEntityType)sequencesEntity.Metadata;
            entityType.AddData(sequences);
        }


    }

    private object GetSequenceInfo(IConventionEntityType type)
    {
        var sequenceName = type.FindAnnotation(AnnotationNames.SequenceName);
        var startsAt = type.FindAnnotation(AnnotationNames.StartsAt);
        var incrementBy = type.FindAnnotation(AnnotationNames.IncrementBy);
        return new
        {
            SequenceName = sequenceName?.Value as string ?? type.Name,
            CurrentValue = (long?)startsAt?.Value ?? 1L,
            IncrementBy = (long?)incrementBy?.Value  ?? 1L,
        };

    }

    private bool HasHiLoSequence(IConventionEntityType type)
    {
        return type.Name != typeof(SequenceTable).FullName && (( (bool?)type.FindAnnotation(AnnotationNames.UseHiLo)?.Value ?? false));
    }
}
