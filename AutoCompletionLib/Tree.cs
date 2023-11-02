using System.Collections;
using System.Text;

namespace AutoCompletionLib
{
    public class Tree
    {
        public NodeWithCache Root { get; set; } = new(' ');

        public IEnumerable<string> FindAllWords(string str)
        {
            var currentNode = Root;
            NodeWithCache newCurNode = null!;
            for (int i = 0; i < str.Length; i++)
            {
                bool haveThisChar = false;
                for (int j = 0; j < currentNode!.Childrens.Count; j++)
                {
                    if (currentNode.Childrens[j].CurrentSimbol == str[i])
                    {
                        haveThisChar = true;
                        newCurNode = currentNode.Childrens[j];
                    }
                }
                if (!haveThisChar)
                {
                    return new string[0];
                }
                currentNode = newCurNode;
            }
            var keys = currentNode.WordsAndCounts.Keys.ToArray();
            var orderKeys = keys.OrderByDescending(key => currentNode.WordsAndCounts[key]);
            return orderKeys;
        }


        public void Add(string str, uint count = 0)
        {
            var currentNode = Root;
            if (!Root.WordsAndCounts.ContainsKey(str))
            {
                Root.CacheWord(str, count);
            }
            NodeWithCache newCurNode = null;
            for (int i = 0; i < str.Length; i++)
            {
                bool haveThisChar = false;
                for (int j = 0; j < currentNode!.Childrens.Count; j++)
                {
                    if (currentNode.Childrens[j].CurrentSimbol == str[i])
                    {
                        haveThisChar = true;
                        newCurNode = currentNode.Childrens[j];
                        if (!newCurNode.WordsAndCounts.ContainsKey(str))
                        {
                            newCurNode.CacheWord(str, count);
                        }
                    }
                }
                if (!haveThisChar)
                {
                    currentNode.Childrens.Add(new(str[i]));
                    newCurNode = currentNode.Childrens.Last();
                    newCurNode.CacheWord(str, count);
                }
                currentNode = newCurNode;
            }
            currentNode!.Terminal = true;
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

        public char Find(NodeWithCache current, List<StringBuilder> listSb, List<string> list,  uint deep = 0)
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
