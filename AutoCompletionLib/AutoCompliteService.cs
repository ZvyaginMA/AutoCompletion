using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCompletionLib
{
    public class AutoCompliteService
    {
        public readonly Tree? PrefTree { get; set; }

        public string[] Complite(string str)
        {
            return new string[0]; 
        }
    }
}
