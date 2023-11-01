namespace AutoCompletionLib
{
    public class Tree
    {
        public Node Root { get; set; } = new(' ');

        public void Add(string str)
        {
            var currentNode = Root;
            Node newCurNode = null;
            for (int i = 0; i < str.Length; i++)
            {
                bool haveThisChar = false;
                for (int j = 0; j < currentNode.Childrens.Count; j++)
                {
                    if (currentNode.Childrens[j].CurrentSimbol == str[i])
                    {
                        haveThisChar = true;
                        newCurNode = currentNode.Childrens[j];
                    }
                }
                if (!haveThisChar)
                {
                    currentNode.Childrens.Add(new(str[i]));
                    newCurNode = currentNode.Childrens.Last();
                }
                currentNode = newCurNode;
            }
            currentNode.Terminal = true;
        }

        public bool Contain(string str)
        {
            var currentNode = Root;
            for(int i = 0; i<str.Length; i++) 
            {
                bool flag = false;
                for (int j = 0; j < currentNode.Childrens.Count; j++)
                {
                    if (currentNode.Childrens[j].CurrentSimbol == str[i])
                    {
                        flag = true;
                        currentNode = currentNode.Childrens[j];
                    }
                }
                if (!flag)
                {
                    return false;
                }
            }
            if (currentNode.Terminal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
