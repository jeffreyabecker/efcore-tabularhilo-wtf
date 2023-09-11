using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

using ConsoleApp2.HiLo.Infrastructure;

namespace ConsoleApp2.HiLo;
public static class DbContextOptionsExtensions
{
    public static DbContextOptionsBuilder UseTabularHiLo(
    this DbContextOptionsBuilder optionsBuilder,
    Action<TabularHiLoDbContextOptionsBuilder>? sqlServerOptionsAction = null)
    {
        var extension = optionsBuilder.Options.FindExtension<TabularHiLoOptionsExtension>()
        ?? new TabularHiLoOptionsExtension();
        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        //ConfigureWarnings(optionsBuilder);

        sqlServerOptionsAction?.Invoke(new TabularHiLoDbContextOptionsBuilder(extension));

        return optionsBuilder;
    }
}
public class TabularHiLoDbContextOptionsBuilder 
{
    private readonly TabularHiLoOptionsExtension _extension;

    public TabularHiLoDbContextOptionsBuilder(TabularHiLoOptionsExtension optionsBuilder) 
    {
        _extension = optionsBuilder;
    }

    /// <summary>
    ///     Configures the name of the table used to record which migrations have been applied to the database.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-migrations">Database migrations</see> for more information and examples.
    /// </remarks>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="schema">The schema of the table.</param>
    /// <returns>The same builder instance so that multiple calls can be chained.</returns>
    public virtual TabularHiLoDbContextOptionsBuilder SequenceTable(string tableName, string? schema = null)
    {
        //Check.NotEmpty(tableName, nameof(tableName));
        //Check.NullButNotEmpty(schema, nameof(schema));

        _extension.SequenceTable(tableName, schema);
        return this;
    }

}