using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace layeredwordindex.contracts
{
    public interface IIndexer
    {
        IIndex BuildIndex(string path);
    }

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
