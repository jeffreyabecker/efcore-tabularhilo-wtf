using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ConsoleApp2.Audits;

public class CurrentTimeValueGenerator<TTimeValue> : ValueGenerator<TTimeValue>
{
    private readonly ICurrentTimeAccessor<TTimeValue> _accessor;

    public CurrentTimeValueGenerator(ICurrentTimeAccessor<TTimeValue> accessor)
    {
        _accessor = accessor;
    }
    public override bool GeneratesTemporaryValues => false;

    public override TTimeValue Next(EntityEntry entry) => _accessor.GetNow();
}
