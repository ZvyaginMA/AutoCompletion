using AutoCompletionLib;

namespace TestAutoComplrtion
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            var tree = new Tree();
            
            tree.Add("Anna");
            tree.Add("Anastasia");

            Assert.Equal('A' ,tree.Root.Childrens[0].CurrentSimbol);
            Assert.Equal('n', tree.Root.Childrens[0].Childrens[0].CurrentSimbol);
            Assert.Equal('n', tree.Root.Childrens[0].Childrens[0].Childrens[0].CurrentSimbol);
            Assert.Equal('a', tree.Root.Childrens[0].Childrens[0].Childrens[1].CurrentSimbol);

            Assert.Equal(2, tree.Root.WordsAndCounts.Count);
            Assert.Equal(2, tree.Root.Childrens[0].WordsAndCounts.Count);
            Assert.Equal(2 ,tree.Root.Childrens[0].Childrens[0].Childrens.Count);
            Assert.Equal(2, tree.Root.Childrens[0].Childrens[0].WordsAndCounts.Count);
            Assert.Single(tree.Root.Childrens[0].Childrens[0].Childrens[0].WordsAndCounts);
            Assert.Single(tree.Root.Childrens[0].Childrens[0].Childrens[1].WordsAndCounts);
        }

        [Fact]
        public void TestContain()
        {
            var tree = new Tree();
            tree.Add("Anna");
            tree.Add("Anastasia");
            Assert.True(tree.Contain("Anna"));
            Assert.True(tree.Contain("Anastasia"));
            Assert.False(tree.Contain("Anas"));
            Assert.False(tree.Contain("Anam"));
        }

        [Fact]
        public void TestAutoCompletion() 
        {
            var tree = new Tree();
            var service = new AutoCompliteService(tree);
            var result = service.Complite("An");
        }
    }
}