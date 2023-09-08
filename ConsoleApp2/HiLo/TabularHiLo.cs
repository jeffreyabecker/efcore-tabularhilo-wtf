using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.SqlServer.Update.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.HiLo;
public class TabularHiLoValueGeneratorState : HiLoValueGeneratorState
{
    public TabularHiLoValueGeneratorState(string sequenceName, int startsAt, int blockSize) : base(blockSize)
    {
        SequenceName = sequenceName;
        StartsAt = startsAt;
        BlockSize = blockSize;
    }

    public string SequenceName { get; }
    public int StartsAt { get; }
    public int BlockSize { get; }
}
public class TabularHiLo<TValue> : ValueGenerator<TValue>

{
    private readonly IRawSqlCommandBuilder _rawSqlCommandBuilder;
    private readonly IUpdateSqlGenerator _sqlGenerator;
    private readonly IRelationalConnection _connection;
    private readonly TabularHiLoValueGeneratorState _generatorState;

    public TabularHiLo(IRawSqlCommandBuilder rawSqlCommandBuilder,
        IUpdateSqlGenerator sqlGenerator,
        IRelationalConnection connection,
        TabularHiLoValueGeneratorState generatorState
        ) 
    {
        _rawSqlCommandBuilder = rawSqlCommandBuilder;
        _sqlGenerator = sqlGenerator;
        _connection = connection;
        _generatorState = generatorState;    
    }

    public override bool GeneratesTemporaryValues => false;

    /// <summary>
    ///     Gets a value to be assigned to a property.
    /// </summary>
    /// <param name="entry">The change tracking entry of the entity for which the value is being generated.</param>
    /// <returns>The value to be assigned to a property.</returns>
    public override TValue Next(EntityEntry entry)
        => _generatorState.Next<TValue>(GetNewLowValue);

    /// <summary>
    ///     Gets a value to be assigned to a property.
    /// </summary>
    /// <param name="entry">The change tracking entry of the entity for which the value is being generated.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>The value to be assigned to a property.</returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    public override ValueTask<TValue> NextAsync(
        EntityEntry entry,
        CancellationToken cancellationToken = default)
        => _generatorState.NextAsync<TValue>(GetNewLowValueAsync, cancellationToken);

    /// <summary>
    ///     Gets the low value for the next block of values to be used.
    /// </summary>
    /// <returns>The low value for the next block of values to be used.</returns>
    protected virtual long GetNewLowValue()
    {
        var cmds = GetNextLowSqlCommands();
        long? nextValue = cmds.NextValueSync();
    }
    private NextLowSqlCommands GetNextLowSqlCommands()
    {

        return new NextLowSqlCommands(_rawSqlCommandBuilder, _generatorState);
    }
    private class NextLowSqlCommands
    {
        private TabularHiLoValueGeneratorState _generatorState;

        public NextLowSqlCommands(IRawSqlCommandBuilder sqlBuilder, TabularHiLoValueGeneratorState generatorState)
        {
            _selectNextValue = sqlBuilder.Build("SELECT NextValue FROM __EFHiLo WHERE SequenceName = {0}", new object[] { generatorState.SequenceName });
            _insertBaseValue = sqlBuilder.Build("INSERT INTO __EFHiLo(SequenceName, NextValue, BlockSize) values({0}, {1}, {2})", new object[] { generatorState.SequenceName, generatorState.StartsAt, generatorState.BlockSize });
            _updateIfExists = sqlBuilder.Build("UPDDATE __EFHiLo SET NextValue = NextValue + {1} WHERE SequenceName = {0}", new object[] { generatorState.SequenceName, generatorState.BlockSize });
        }

        private readonly RawSqlCommand _selectNextValue;
        private readonly RawSqlCommand _insertBaseValue;
        private readonly RawSqlCommand _updateIfExists;

        public long? NextValueSync()
        {
            _selectNextValue.RelationalCommand.ExecuteScalar()
        }
    }

    /// <summary>
    ///     Gets the low value for the next block of values to be used.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>The low value for the next block of values to be used.</returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    protected virtual Task<long> GetNewLowValueAsync(CancellationToken cancellationToken = default)
    {

    }
}
