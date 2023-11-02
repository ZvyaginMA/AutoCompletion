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
            Assert.Equal(2, tree.Root.Childrens[0].Childrens[0].Childrens.Count);

            Assert.Equal(2, tree.Root.WordsAndCounts.Count);
            Assert.Equal(2, tree.Root.Childrens[0].WordsAndCounts.Count);
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
            tree.Add("Anna", 3);
            tree.Add("Anastasia", 2);
            tree.Add("Alesya", 9);
            tree.Add("Angel", 1);
            var service = new AutoCompliteService(tree);

            var query1 = "B";
            var result1 = service.Complite(query1);
            Assert.True(result1.ToArray().Length == 0);

            var query2 = "A";
            var result2 = service.Complite(query2).ToArray();
            Assert.Equal("Alesya", result2[0]);
            Assert.Equal("Anna", result2[1]);
            Assert.Equal("Anastasia", result2[2]);
            Assert.Equal("Angel", result2[3]);
            Assert.True(result2.ToArray().Length == 4);

            var query3 = "An";
            var result3 = service.Complite(query3);
            Assert.True(result3.ToArray().Length == 3);

            var query4 = "Ana";
            var result4 = service.Complite(query4);
            Assert.True(result4.ToArray().Length == 1);
            Assert.Equal("Anastasia", result4.First());
        }
    }
}