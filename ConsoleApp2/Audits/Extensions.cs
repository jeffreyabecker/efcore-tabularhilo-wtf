using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ConsoleApp2.Audits;
public record AuditPropertiesModel(
    string CreateUserName,
    string UpdateUserName,
    string CreateTimestampName,
    string UpdateTimestampName,
    ValueGenerated UpdateMode = ValueGenerated.OnAddOrUpdate
)
{

}
public class AuditPropertiesModel<TUserValue, TTimeValue>
{
    public TUserValue CreatedUser { get; set; }
    public TUserValue UpdatedUser { get; set; }
    public TTimeValue CreatedTimestamp { get; set; }
    public TTimeValue UpdateTimestamp { get; set; }


}


public interface IApplyAuditProperties
{
    EntityTypeBuilder<TEntity> ApplyAudits<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : class;

}
public class AuditPropertiesApplicator<TUserValue, TTimeValue> : IApplyAuditProperties
{
    private readonly AuditPropertiesModel _model;

    public AuditPropertiesApplicator(AuditPropertiesModel model)
    {
        _model = model;
    }
    private class CurrentUserValueGeneratorFactory : ValueGeneratorFactory
    {
        public CurrentUserValueGeneratorFactory()
        {
        }

        public override ValueGenerator Create(IProperty property, IEntityType entityType)
        {
            throw new NotImplementedException();
        }
    }
    public EntityTypeBuilder<TEntity> ApplyAudits<TEntity>(EntityTypeBuilder<TEntity> builder)
        where TEntity : class
    {
        var props = typeof(TEntity).GetProperties();
        if (props.Any(p => p.Name == _model.CreateUserName))
        {
            var propertyBuilder = builder.Property(_model.CreateUserName);

            //propertyBuilder.HasValueGenerator((prop, entityType)=> new CurrentUserValueGenerator<TUserValue> (new )>();
            //propertyBuilder.ValueGeneratedOnAdd();
        }
        //if (props.Any(p => p.Name == _model.CreateTimestampName))
        //{
        //    var propertyBuilder = builder.Property(_model.CreateTimestampName);
        //    propertyBuilder.HasValueGenerator<CurrentTimeValueGenerator<TTimeValue>>();
        //    propertyBuilder.ValueGeneratedOnAdd();

        //}
        //if (props.Any(p => p.Name == _model.UpdateUserName))
        //{
        //    var propertyBuilder = builder.Property(_model.UpdateUserName);
        //    propertyBuilder.HasValueGenerator<CurrentUserValueGenerator<TUserValue>>();
        //    if (_model.UpdateMode == ValueGenerated.OnUpdate)
        //    {
        //        propertyBuilder.ValueGeneratedOnUpdate();
        //    }
        //    else if (_model.UpdateMode == ValueGenerated.OnAddOrUpdate)
        //    {
        //        propertyBuilder.ValueGeneratedOnUpdate();
        //    }
        //}

        //if (props.Any(p => p.Name == _model.UpdateTimestampName))
        //{
        //    var propertyBuilder = builder.Property(_model.UpdateTimestampName);
        //    propertyBuilder.HasValueGenerator<CurrentTimeValueGenerator<TTimeValue>>();
        //    if (_model.UpdateMode == ValueGenerated.OnUpdate)
        //    {
        //        propertyBuilder.ValueGeneratedOnUpdate();
        //    }
        //    else if (_model.UpdateMode == ValueGenerated.OnAddOrUpdate)
        //    {
        //        propertyBuilder.ValueGeneratedOnUpdate();
        //    }
        //}
        return builder;
    }
}


public static class AuditProperties
{
    private static IApplyAuditProperties _auditPropertyApplicator = null;
    public static void Init(IApplyAuditProperties applicator)
    {
        _auditPropertyApplicator = applicator;
    }
    public static void Init<TUserValue, TTimeValue>(AuditPropertiesModel model)
    {
        Init(new AuditPropertiesApplicator<TUserValue, TTimeValue>(model));
    }
    public static void Init<TUserValue, TTimeValue>(string createUserName,
    string updateUserName,
    string createTimestampName,
    string updateTimestampName,
    ValueGenerated updateMode = ValueGenerated.OnAddOrUpdate)
    {
        Init<TUserValue, TTimeValue>(new AuditPropertiesModel(createUserName, updateUserName, createTimestampName, updateTimestampName, updateMode));
    }

    public static void Init<TEntity, TUserValue, TTimeValue>(
        Expression<Func<TEntity, TUserValue?>> createdUserProperty,
        Expression<Func<TEntity, TUserValue?>> updatedUserProperty,
        Expression<Func<TEntity, TTimeValue?>> createdTimestampProperty,
        Expression<Func<TEntity, TTimeValue?>> updatedTimestampProperty,
        ValueGenerated updateMode = ValueGenerated.OnAddOrUpdate
        )
    {
        Init<TUserValue, TTimeValue>(
                createdUserProperty.GetPropertyAccess()?.Name!,
                updatedUserProperty.GetPropertyAccess()?.Name!,
                createdTimestampProperty.GetPropertyAccess()?.Name!,
                updatedTimestampProperty.GetPropertyAccess()?.Name!,
                updateMode);
    }
    public static EntityTypeBuilder<TEntity> HasAuditProperties<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class
    {
        if (_auditPropertyApplicator == null)
        {
            throw new NotImplementedException("AuditFieldsExtensions has not been initialized");
        }
        return _auditPropertyApplicator.ApplyAudits(builder);
    }
}