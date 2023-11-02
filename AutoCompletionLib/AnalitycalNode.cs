namespace AutoCompletionLib
{
    public class AnalitycalNode
    {
        public char CurrentSimbol { get; set; }
        public bool Terminal { get; set; } = false;

        public List<AnalitycalNode> Childrens { get; set; }
        public Dictionary<string, uint> WordsAndCounts { get; set; } = new();
        public AnalitycalNode(char s)
        {
            CurrentSimbol = s;
            Childrens = new();
        }

        public override string ToString()
        {
            return $"{CurrentSimbol}, is teminal: {Terminal}";
        }
    }
}