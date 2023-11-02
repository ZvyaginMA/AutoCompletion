using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCompletionLib
{
    internal class AnalitycalNode : Node
    {
        public Dictionary<string, uint> WordsAndCounts = new();

        public AnalitycalNode(char s) : base(s)
        {
        }
    }
}
