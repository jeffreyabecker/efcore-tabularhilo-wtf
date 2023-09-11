using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.HiLo.Metadata;
public class AnnotationNames
{
    public const string Prefix = "TabularHiLo:";
    public const string UseHiLo = Prefix + nameof(UseHiLo);
    public const string SequenceName = Prefix + nameof(SequenceName);
    public const string StartsAt = Prefix + nameof(StartsAt);
    public const string IncrementBy = Prefix + nameof(IncrementBy);
    public const string SequenceTableName = Prefix + nameof(SequenceTableName);
}
