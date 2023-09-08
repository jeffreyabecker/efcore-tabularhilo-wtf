namespace ConsoleApp2.Audits;

public interface ICurrentTimeAccessor<TTimeValue>
{
    TTimeValue GetNow();
}
