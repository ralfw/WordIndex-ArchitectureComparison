using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using npantarhei.runtime;
using npantarhei.runtime.config;
using npantarhei.runtime.operations;

namespace obliviouswordindex
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new FlowRuntimeConfiguration()
                                .AddStreamsFrom("obliviouswordindex.root.flow", Assembly.GetExecutingAssembly())
                                .AddOperations(new AssemblyCrawler(typeof (frontend.Console).Assembly,
                                                                   typeof (domain.Indexer).Assembly,
                                                                   typeof (persistence.TextfileDocuments).Assembly));

            using(var fr = new FlowRuntime(config, new Schedule_for_sync_depthfirst_processing()))
            {
                fr.Process(".run", args);
            }
        }
    }
}
