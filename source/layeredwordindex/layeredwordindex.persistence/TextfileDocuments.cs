using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using layeredwordindex.contracts;

namespace layeredwordindex.persistence
{
    public class TextfileDocuments : IDocuments
    {
        public IEnumerable<string> FindDocuments(string path)
        {
            return Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
        }

        public IEnumerable<string> LoadDocument(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }
}
