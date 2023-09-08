using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ConsoleApp2.Audits;

public class CurrentUserValueGenerator<TUserValue> : ValueGenerator<TUserValue>
{
    private readonly ICurrentUserValueAccessor<TUserValue> _accessor;

    public CurrentUserValueGenerator(ICurrentUserValueAccessor<TUserValue> accessor)
    {
        _accessor = accessor;
    }
    public override bool GeneratesTemporaryValues => false;

    public override TUserValue Next(EntityEntry entry) => _accessor.GetUserValue();
}
