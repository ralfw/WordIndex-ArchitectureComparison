using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using layeredwordindex.contracts;

namespace layeredwordindex
{
    class Program
    {
        static void Main(string[] args)
        {
            // build & compose
            IConsole con = new frontend.Console(
                                new domain.Indexer(
                                        new persistence.TextfileDocuments()
                                        )
                                    );
            // run
            con.Run(args);
        }
    }
}
