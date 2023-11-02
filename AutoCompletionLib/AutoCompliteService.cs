using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCompletionLib
{
    public class AutoCompliteService
    {
        public Tree PrefTree { get; private set; }

        public AutoCompliteService(Tree tree)
        {
            PrefTree = tree;
        }

        public string[] Complite(string str)
        {
            return new string[0]; 
        }
    }
}
