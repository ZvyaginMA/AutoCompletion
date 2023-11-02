using System.Collections;
using System.Text;

namespace AutoCompletionLib
{
    public class Tree
    {
        public AnalitycalNode Root { get; set; } = new(' ');

        public void Add(string str)
        {
            var currentNode = Root;
            if (!Root.WordsAndCounts.ContainsKey(str))
            {
                Root.WordsAndCounts.Add(str, 0);
            }
            AnalitycalNode newCurNode = null;
            for (int i = 0; i < str.Length; i++)
            {
                bool haveThisChar = false;
                for (int j = 0; j < currentNode.Childrens.Count; j++)
                {
                    if (currentNode.Childrens[j].CurrentSimbol == str[i])
                    {
                        haveThisChar = true;
                        newCurNode = currentNode.Childrens[j];
                        if (!newCurNode.WordsAndCounts.ContainsKey(str))
                        {
                            newCurNode.WordsAndCounts.Add(str, 0);
                        }
                    }
                }
                if (!haveThisChar)
                {
                    currentNode.Childrens.Add(new(str[i]));
                    newCurNode = currentNode.Childrens.Last();
                    newCurNode.WordsAndCounts.Add(str, 0);
                }
                currentNode = newCurNode;
            }
            currentNode.Terminal = true;
        }

        public bool Contain(string str)
        {
            return Root.WordsAndCounts.ContainsKey(str);
        }

        public void AddStrings(IEnumerable<string> strs)
        {
            foreach(var s in strs)
            {
                Add(s);
            }
        }

        public char Find(AnalitycalNode current, List<StringBuilder> listSb, List<string> list,  uint deep = 0)
        {
            if(deep == 0)
            {
                listSb.Add(new StringBuilder());
            }
            if (current.Terminal)
            {
                list.Add(listSb.Last().ToString());
            }
            if(current.Childrens.Count == 1)
            {
                listSb.Last().Append(current.Childrens[0]);
                Find(current.Childrens[0], listSb, list,  deep + 1);
            }
            return ' ';
        }
    }
}
