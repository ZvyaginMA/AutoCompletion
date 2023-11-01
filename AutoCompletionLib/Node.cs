namespace AutoCompletionLib
{
    public class Node
    {
        public char CurrentSimbol { get; set; }
        public bool Terminal { get; set; } = false;
        public List<Node> Childrens { get; set; }

        public Node(char s)
        {
            CurrentSimbol = s;
            Childrens = new List<Node>();
        }

        public override string ToString()
        {
            return $"{CurrentSimbol}, is teminal: {Terminal}";
        }
    }
}