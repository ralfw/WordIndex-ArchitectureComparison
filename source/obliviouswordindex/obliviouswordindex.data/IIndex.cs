using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace obliviouswordindex.data
{
    public interface IIndex
    {
        IEnumerable<IEntry> Entries { get; }
    }

    public interface IEntry
    {
        string Word { get; }
        IEnumerable<string> DocumentNames { get; }
    }
}
