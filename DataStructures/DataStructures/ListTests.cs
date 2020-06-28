using Xunit;

namespace DataStructures
{
    public class ListTests
    {
        [Fact]
        public void ValidatesConstructor()
        {
            var test = new List<int>();
            Assert.Empty(test);
            Assert.Equal(0, test[0]);
            Assert.Equal(0, test[1]);
            Assert.Equal(0, test[2]);
            Assert.Equal(0, test[3]);
        }

        [Fact]
        public void ValidatesAddMethod()
        {
            var test = new List<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(6);
            test.Add(7);
            Assert.Equal(1, test[0]);
            Assert.Equal(2, test[1]);
            Assert.Equal(3, test[2]);
            Assert.Equal(6, test[3]);
            Assert.Equal(7, test[4]);
        }

        [Fact]
        public void ValidatesCountMethod()
        {
            var test = new List<int>();
            test.Add(5);
            test.Add(3);
            test.Add(2);
            test.Add(6);
            test.Add(7);
            Assert.Equal(5, test.Count);
        }

        [Fact]
        public void ValidatesSetElementMethod()
        {
            var test = new List<int>();
            test.Add(5);
            test[0] = 6;
            Assert.Equal(6, test[0]);
        }

        [Fact]
        public void ValidatesContainMethodAndFindsElement()
        {
            var test = new List<int>();
            test.Add(1);
            test.Add(3);
            Assert.Contains(1, test);
        }

        [Fact]
        public void ValidatesContainMethodAndDoesNotFindElement()
        {
            var test = new List<int>();
            test.Add(1);
            test.Add(3);
            Assert.DoesNotContain(2, test);
        }

        [Fact]
        public void ValidatesIndexOfMethodAndReturnsIndex()
        {
            var test = new List<int>();
            test.Add(5);
            test.Add(3);
            Assert.Equal(1, test.IndexOf(3));
        }

        [Fact]
        public void ValidatesIndexOfMethodAndDoesNotReturnIndex()
        {
            var test = new List<int>();
            test.Add(5);
            test.Add(4);
            Assert.Equal(-1, test.IndexOf(1000));
        }

        [Fact]
        public void ValidatesInsertMethod()
        {
            var test = new List<int>();
            test.Add(5);
            test.Add(3);
            test.Insert(0, 1);
            Assert.Equal(1, test[0]);
            Assert.Equal(5, test[1]);
            Assert.Equal(3, test[2]);
            Assert.Equal(3, test.Count);
        }

        [Fact]
        public void ValidatesClearMethod()
        {
            var test = new List<int> { 5, 3 };

            test.Clear();
            Assert.Empty(test);
        }

        [Fact]
        public void ValidatesRemoveMethod()
        {
            var test = new List<int>();
            test.Add(5);
            test.Add(3);
            test.Remove(5);
            Assert.Equal(3, test[0]);
        }

        [Fact]
        public void ValidatesRemoveAtMethod()
        {
            var test = new List<int>();
            test.Add(5);
            test.Add(3);
            test.RemoveAt(0);
            Assert.Equal(3, test[0]);
        }

        [Fact]
        public void ValidatesIListRemoveMethodAndDoesNotFindElement()
        {
            var test = new List<int>();
            test.Add(5);
            test.Add(6);
            test.Add(4);
            test.Add(1);
            Assert.False(test.Remove(15));
        }

        [Fact]
        public void ValidatesIListRemoveMethod()
        {
            var test = new List<int>();
            test.Add(5);
            test.Add(6);
            test.Add(4);
            test.Add(1);
            Assert.True(test.Remove(5));
        }
    }
}
