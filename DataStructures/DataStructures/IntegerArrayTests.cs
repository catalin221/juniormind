using Xunit;

namespace DataStructures
{
    public class IntegerArrayTests
    {
        [Fact]
        public void ValidatesConstructor()
        {
            var test = new IntArray();
            Assert.Equal(0, test.Count());
            Assert.Equal(0, test.Element(0));
            Assert.Equal(0, test.Element(1));
            Assert.Equal(0, test.Element(2));
            Assert.Equal(0, test.Element(3));
        }

        [Fact]
        public void ValidatesAddMethod()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            test.Add(2);
            test.Add(6);
            test.Add(7);
            Assert.Equal(5, test.Element(0));
            Assert.Equal(3, test.Element(1));
            Assert.Equal(2, test.Element(2));
            Assert.Equal(6, test.Element(3));
            Assert.Equal(7, test.Element(4));
        }

        [Fact]
        public void ValidatesCountMethod()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            test.Add(2);
            test.Add(6);
            test.Add(7);
            Assert.Equal(5, test.Count());
        }

        [Fact]
        public void ValidatesSetElementMethod()
        {
            var test = new IntArray();
            test.Add(5);
            test.SetElement(0, 2);
            Assert.Equal(2, test.Element(0));
        }

        [Fact]
        public void ValidatesContainMethodAndFindsElement()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            Assert.True(test.Contains(3));
        }

        [Fact]
        public void ValidatesContainMethodAndDoesNotFindElement()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            Assert.False(test.Contains(2));
        }

        [Fact]
        public void ValidatesIndexOfMethodAndReturnsIndex()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            Assert.Equal(1, test.IndexOf(3));
        }

        [Fact]
        public void ValidatesIndexOfMethodAndDoesNotReturnIndex()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            Assert.Equal(-1, test.IndexOf(1000));
        }

        [Fact]
        public void ValidatesInsertMethod()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            test.Insert(0, 4);
            Assert.Equal(4, test.Element(0));
            Assert.Equal(5, test.Element(1));
            Assert.Equal(3, test.Element(2));
            Assert.Equal(3, test.Count());
        }

        [Fact]
        public void ValidatesClearMethod()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            test.Clear();
            Assert.Equal(0, test.Count());
        }

        [Fact]
        public void ValidatesRemoveMethod()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            test.Remove(5);
            Assert.Equal(3, test.Element(0));
        }

        [Fact]
        public void ValidatesRemoveAtMethod()
        {
            var test = new IntArray();
            test.Add(5);
            test.Add(3);
            test.RemoveAt(0);
            Assert.Equal(3, test.Element(0));
        }
    }
}
