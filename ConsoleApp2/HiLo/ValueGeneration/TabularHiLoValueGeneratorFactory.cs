using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ConsoleApp2.HiLo.ValueGeneration;

public interface ITabularHiLoValueGeneratorFactory
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    ValueGenerator? TryCreate(
        IProperty property,
        Type clrType,
        TabularHiLoValueGeneratorState generatorState,
        IRelationalConnection connection,
        IRelationalCommandDiagnosticsLogger commandLogger);
}
public class TabularHiLoValueGeneratorFactory : ITabularHiLoValueGeneratorFactory
{
    private readonly IUpdateSqlGenerator _updateSqlGenerator;

    public TabularHiLoValueGeneratorFactory(IUpdateSqlGenerator updateSqlGenerator)
    {
        _updateSqlGenerator = updateSqlGenerator;
    }
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public ValueGenerator? TryCreate(
        IProperty property,
        Type type,
        TabularHiLoValueGeneratorState generatorState,
        IRelationalConnection connection,
        IRelationalCommandDiagnosticsLogger commandLogger)
    {

        if (type == typeof(long))
        {
            return new TabularHiLoValueGenerator<long>(generatorState);
        }

        if (type == typeof(int))
        {
            return new TabularHiLoValueGenerator<int>(generatorState);
        }

        if (type == typeof(decimal))
        {
            return new TabularHiLoValueGenerator<decimal>(generatorState);
        }

        if (type == typeof(short))
        {
            return new TabularHiLoValueGenerator<short>(generatorState);
        }

        if (type == typeof(byte))
        {
            return new TabularHiLoValueGenerator<byte>(generatorState);
        }

        if (type == typeof(char))
        {
            return new TabularHiLoValueGenerator<char>(generatorState);
        }

        if (type == typeof(ulong))
        {
            return new TabularHiLoValueGenerator<ulong>(generatorState);
        }

        if (type == typeof(uint))
        {
            return new TabularHiLoValueGenerator<uint>(generatorState);
        }

        if (type == typeof(ushort))
        {
            return new TabularHiLoValueGenerator<ushort>(generatorState);
        }

        if (type == typeof(sbyte))
        {
            return new TabularHiLoValueGenerator<sbyte>(generatorState);
        }

        return null;
    }
}