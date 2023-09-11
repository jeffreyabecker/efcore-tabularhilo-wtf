using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;


namespace ConsoleApp2.HiLo.Infrastructure;
public class TabularHiLoOptionsExtension : IDbContextOptionsExtension
{
    private DbContextOptionsExtensionInfo? _info;

    public TabularHiLoOptionsExtension() : base() { }



    public void ApplyServices(IServiceCollection services)
    {
        services.AddTabularHiLo();
    }

    public void Validate(IDbContextOptions options)
    {

    }

    public void SequenceTable(string tableName, string? schema)
    {
        throw new NotImplementedException();
    }

    public DbContextOptionsExtensionInfo Info => _info ??= new ExtensionInfo(this);

    private sealed class ExtensionInfo : DbContextOptionsExtensionInfo
    {
        private string? _logFragment;

        public ExtensionInfo(IDbContextOptionsExtension extension)
            : base(extension)
        {
        }

        private new TabularHiLoOptionsExtension Extension
            => (TabularHiLoOptionsExtension)base.Extension;

        public override bool IsDatabaseProvider
            => false;

        public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other)
            => other is ExtensionInfo;

        public override string LogFragment => String.Empty;


        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
            => debugInfo["TabularHiLo"] = "1";

        public override int GetServiceProviderHashCode()
        {
            return this.GetHashCode();
        }
    }
}
