using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using layeredwordindex.contracts;

namespace layeredwordindex.frontend
{
    public class Console : IConsole
    {
        private readonly IIndexer _indexer;

        public Console(IIndexer indexer)
        {
            _indexer = indexer;
        }


        public void Run(string[] args)
        {
            var rootPath = args[0];

            var index = _indexer.BuildIndex(rootPath);

            Dump_index(index);
        }


        private void Dump_index(IIndex index)
        {
            foreach(var e in index.Entries)
            {
                System.Console.WriteLine("{0}", e.Word);
                foreach(var dn in e.DocumentNames)
                    System.Console.WriteLine("\t{0}", dn);
            }
        }
    }
}
