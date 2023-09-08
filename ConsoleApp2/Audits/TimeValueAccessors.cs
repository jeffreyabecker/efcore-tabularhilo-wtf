namespace ConsoleApp2.Audits;

public class TimeValueAccessors
{
    public static class Nullable
    {
        public static ICurrentTimeAccessor<DateTime?> DateTimeNow = new NullableDateTimeNowAccessor();
        public static ICurrentTimeAccessor<DateTime?> DateTimeUtcNow = new NullableDateTimeUtcNowAccessor();
        public static ICurrentTimeAccessor<DateTimeOffset?> DateTimeOffsetNow = new NullableDateTimeOffsetNowAccessor();
        public static ICurrentTimeAccessor<DateTimeOffset?> DateTimeOffsetUtcNow = new NullableDateTimeOffsetUtcNowAccessor();
        private class NullableDateTimeNowAccessor : ICurrentTimeAccessor<DateTime?>
        {
            public DateTime? GetNow() => DateTime.Now;
        }
        private class NullableDateTimeUtcNowAccessor : ICurrentTimeAccessor<DateTime?>
        {
            public DateTime? GetNow() => DateTime.UtcNow;
        }
        private class NullableDateTimeOffsetNowAccessor : ICurrentTimeAccessor<DateTimeOffset?>
        {
            public DateTimeOffset? GetNow() => DateTimeOffset.Now;
        }
        private class NullableDateTimeOffsetUtcNowAccessor : ICurrentTimeAccessor<DateTimeOffset?>
        {
            public DateTimeOffset? GetNow() => DateTimeOffset.UtcNow;
        }
    }
    public static readonly ICurrentTimeAccessor<DateTime> DateTimeNow = new DateTimeNowAccessor();
    public static readonly ICurrentTimeAccessor<DateTime> DateTimeUtcNow = new DateTimeUtcNowAccessor();
    public static readonly ICurrentTimeAccessor<DateTimeOffset> DateTimeOffsetNow = new DateTimeOffsetNowAccessor();
    public static readonly ICurrentTimeAccessor<DateTimeOffset> DateTimeOffsetUtcNow = new DateTimeOffsetUtcNowAccessor();
    private class DateTimeNowAccessor : ICurrentTimeAccessor<DateTime>
    {
        public DateTime GetNow() => DateTime.Now;
    }
    private class DateTimeUtcNowAccessor : ICurrentTimeAccessor<DateTime>
    {
        public DateTime GetNow() => DateTime.UtcNow;
    }
    private class DateTimeOffsetNowAccessor : ICurrentTimeAccessor<DateTimeOffset>
    {
        public DateTimeOffset GetNow() => DateTimeOffset.Now;
    }
    private class DateTimeOffsetUtcNowAccessor : ICurrentTimeAccessor<DateTimeOffset>
    {
        public DateTimeOffset GetNow() => DateTimeOffset.UtcNow;
    }
}
