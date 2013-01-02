using System.Collections.Generic;
using System.Linq;
using obliviouswordindex.data;

namespace obliviouswordindex.domain
{
    public class Index : IIndex
    {
        private readonly List<KeyValuePair<string, string>> _rawEntries = new List<KeyValuePair<string, string>>();

        public IEnumerable<IEntry> Entries
        {
            get
            {
                return _rawEntries.GroupBy(re => re.Key,
                                           re => re.Value,
                                           (word, docnames) => new Entry(word, docnames.Distinct()))
                                  .OrderBy(e => e.Word)
                                  .ToArray();
            }
        }

        internal void Add(string word, string documentName)
        {
            _rawEntries.Add(new KeyValuePair<string, string>(word, documentName));
        }


        public class Entry : IEntry
        {
            public Entry(string word, IEnumerable<string> documentNames)
            {
                Word = word;
                DocumentNames = documentNames;
            }

            public string Word { get; private set; }
            public IEnumerable<string> DocumentNames { get; private set; }
        }
    }
}