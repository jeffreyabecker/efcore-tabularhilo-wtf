using ConsoleApp2.HiLo.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ConsoleApp2.HiLo;
public static class HiLoModelBuilderExtensions
{
    public static void UseTabularHiLo(this PropertyBuilder prop, string sequenceName = null, long startsAt = 1L, long incrementBy = 10L)
    {
        
        var rootType = prop.Metadata.DeclaringEntityType.GetRootType();
        rootType.AddAnnotation(AnnotationNames.UseHiLo, true);
        if(sequenceName == null)
        {
            sequenceName = rootType.ClrType?.Name ?? rootType.Name;
        }
        rootType.AddAnnotation(AnnotationNames.SequenceName, sequenceName);
        rootType.AddAnnotation(AnnotationNames.StartsAt, 1L);
        rootType.AddAnnotation(AnnotationNames.IncrementBy, 10L);
        prop.Metadata.AddAnnotation(AnnotationNames.UseHiLo, true);
        //Todo clear out any generation options on the property and set our value generator;
    }
}
