namespace ConsoleApp2.HiLo.Metadata;
public class SequenceTable
{
    public const string DefaultTableName = "__EFCoreHiLoSequences";
    public string SequenceName { get; set; } = String.Empty;
    public long CurrentValue { get; set; } = 1;
    public long IncrementBy { get; set; } = 10;
}
