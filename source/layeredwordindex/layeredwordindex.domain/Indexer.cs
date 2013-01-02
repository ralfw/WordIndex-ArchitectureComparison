using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using layeredwordindex.contracts;

namespace layeredwordindex.domain
{
    public class Indexer : IIndexer
    {
        private readonly IDocuments _docs;

        public Indexer(IDocuments docs)
        {
            _docs = docs;
        }

        public IIndex BuildIndex(string path)
        {
            var inx = new Index();

            _docs.FindDocuments(path)
                .Select(docname => new {Name = docname, Content = _docs.LoadDocument(docname)})
                .Select(doc => new {doc.Name, Words = Parse_document(doc.Content)})
                .SelectMany(docWords => docWords.Words.Select(word => new {Word = word, DocName=docWords.Name}))
                .Where(occurrence => occurrence.Word.Length >= 3)
                .ToList()
                .ForEach(occurrence => inx.Add(occurrence.Word, occurrence.DocName));

            return inx;
        }

        private IEnumerable<string> Parse_document(IEnumerable<string> doc)
        {
            return doc.SelectMany(line => line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
