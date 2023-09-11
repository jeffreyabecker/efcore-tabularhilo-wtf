using ConsoleApp2.HiLo.Metadata;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ConsoleApp2.HiLo.ValueGeneration;
public class HiLoValueGeneratorSelector : RelationalValueGeneratorSelector
{
    public HiLoValueGeneratorSelector(ValueGeneratorSelectorDependencies dependencies) : base(dependencies)
    {
    }
    public override ValueGenerator Select(IProperty property, IEntityType entityType)
    {
        if (property.GetValueGeneratorFactory() == null && ((bool?)property.GetAnnotation(AnnotationNames.UseHiLo)?.Value ?? false))
        {

        }
        throw new NotImplementedException();
    }
}
