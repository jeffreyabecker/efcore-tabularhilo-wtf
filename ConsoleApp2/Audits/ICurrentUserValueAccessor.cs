namespace ConsoleApp2.Audits;

public interface ICurrentUserValueAccessor<TUserValue>
{
    TUserValue GetUserValue();
}
