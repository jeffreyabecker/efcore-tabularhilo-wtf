using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace ConsoleApp2.HiLo.Metadata.Conventions;
public class HiLoConventionSetPlugin : IConventionSetPlugin
{
    public ConventionSet ModifyConventions(ConventionSet conventionSet)
    {
        if(!conventionSet.ModelFinalizingConventions.Any(c=>c is SequenceTableConvention))
        {
            conventionSet.Add(new SequenceTableConvention());
        }
        
        return conventionSet;
    }
}
