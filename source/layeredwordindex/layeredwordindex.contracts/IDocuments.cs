using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace layeredwordindex.contracts
{
    public interface IDocuments
    {
        IEnumerable<string> FindDocuments(string path);
        IEnumerable<string> LoadDocument(string filename);
    }
}
