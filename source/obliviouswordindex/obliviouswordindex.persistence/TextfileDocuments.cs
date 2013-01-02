using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using npantarhei.runtime.contract;
using obliviouswordindex.data;

namespace obliviouswordindex.persistence
{
    [StaticOperations]
    public class TextfileDocuments
    {
        public static void Find_docs(string path, Action<string> filename)
        {
            Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories)
                     .ToList()
                     .ForEach(filename);
            filename(null);
        }
 

        public static Document Load_doc(string filename)
        {
            if (filename == null) return null;

            return new Document(filename, File.ReadAllLines(filename));
        }
    } 
}
