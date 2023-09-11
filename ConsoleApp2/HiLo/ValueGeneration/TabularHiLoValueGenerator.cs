using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;


namespace ConsoleApp2.HiLo.ValueGeneration;



public class TabularHiLoValueGenerator<TValue> : ValueGenerator<TValue>

{

    private readonly TabularHiLoValueGeneratorState _generatorState;

    public TabularHiLoValueGenerator(
        TabularHiLoValueGeneratorState generatorState
        )
    {
        _generatorState = generatorState;
    }

    public override bool GeneratesTemporaryValues => false;

    /// <summary>
    ///     Gets a value to be assigned to a property.
    /// </summary>
    /// <param name="entry">The change tracking entry of the entity for which the value is being generated.</param>
    /// <returns>The value to be assigned to a property.</returns>
    public override TValue Next(EntityEntry entry) => _generatorState.Next<TValue>(() => GetSequenceAccessor(entry.Context).Next());

    private ITabularSequenceAccessor GetSequenceAccessor(DbContext context)
    {
        throw new NotImplementedException();
    }

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
        => _generatorState.NextAsync<TValue>((ct) => GetSequenceAccessor(entry.Context).NextAsync(ct), cancellationToken);

    /// <summary>
    ///     Gets the low value for the next block of values to be used.
    /// </summary>
    /// <returns>The low value for the next block of values to be used.</returns>
    protected virtual long GetNewLowValue() => throw new NotImplementedException("call the version with the context");

    /// <summary>
    ///     Gets the low value for the next block of values to be used.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>The low value for the next block of values to be used.</returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    protected virtual Task<long> GetNewLowValueAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException("call the version with the context");

}
