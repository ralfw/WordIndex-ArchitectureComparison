using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace obliviouswordindex.data
{
    public class Document
    {
        public string Filename { get; private set; }
        public IEnumerable<string> Content { get; private set; }

        public Document(string filename, IEnumerable<string> content)
        {
            Filename = filename;
            Content = content;
        }
    }
}
