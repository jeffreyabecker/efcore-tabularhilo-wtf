using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ConsoleApp2.HiLo.ValueGeneration;

public class TabularHiLoValueGeneratorState : HiLoValueGeneratorState
{
    public TabularHiLoValueGeneratorState(string sequenceName, int blockSize) : base(blockSize)
    {
        SequenceName = sequenceName;

        BlockSize = blockSize;

    }

    public string SequenceName { get; }
    public int BlockSize { get; }
}
