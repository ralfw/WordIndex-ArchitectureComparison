using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Linq;
using npantarhei.runtime.contract;
using obliviouswordindex.data;

namespace obliviouswordindex.domain
{
    [InstanceOperations]
    public class Indexer
    {
        public void Parse_doc(Document doc, Action<dynamic> occurrence)
        {
            if (doc == null) { occurrence(null); return; }

            foreach(var line in doc.Content)
            {
                IEnumerable<string> words = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                foreach(var w in words)
                {
                    dynamic occ = new ExpandoObject();
                    occ.Word = w;
                    occ.Filename = doc.Filename;
                    occurrence(occ);
                }
            }
        }


        public void Filter_occurrence(dynamic occurrence, Action<dynamic> filtered_occurrence)
        {
            if (occurrence == null) { filtered_occurrence(null); return; }

            if (occurrence.Word.Length >= 3) filtered_occurrence(occurrence);
        }


        private Index _index;

        public void Register_occurrence(dynamic occurrence, Action<IIndex> index_completed)
        {
            if (_index == null) _index = new Index();

            if (occurrence == null) { index_completed(_index); _index = null; return; }

            _index.Add(occurrence.Word, occurrence.Filename);
        }
    }
}
