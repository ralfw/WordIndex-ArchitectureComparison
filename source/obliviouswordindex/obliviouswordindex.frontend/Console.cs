using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using npantarhei.runtime.contract;
using obliviouswordindex.data;

namespace obliviouswordindex.frontend
{
    [StaticOperations]
    public class Console
    {
        public static string Get_root_path(string[] args)
        {
            return args[0];
        }


        public static void Output_index(IIndex index)
        {
            foreach (var e in index.Entries)
            {
                System.Console.WriteLine("{0}", e.Word);
                foreach (var dn in e.DocumentNames)
                    System.Console.WriteLine("\t{0}", dn);
            }
        }
    }
}
