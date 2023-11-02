namespace AutoCompletionLib
{
    public class NodeWithCache
    {
        public char CurrentSimbol { get; set; }
        public bool Terminal { get; set; } = false;

        public List<NodeWithCache> Childrens { get; set; }
        public Dictionary<string, uint> WordsAndCounts { get; set; } = new();
        public NodeWithCache(char s)
        {
            CurrentSimbol = s;
            Childrens = new();
        }

        public override string ToString()
        {
            return $"{CurrentSimbol}, is teminal: {Terminal}";
        }

        public void CacheWord(string word, uint count)
        {
            WordsAndCounts.Add(word, count);
        }
    }
}