using Xunit;

namespace DataStructures
{
    public class ObjArrayCollectionTests
    {
        [Fact]
        public void ValidatesConstructor()
        {
            var test = new ObjArrayCollection();
            Assert.Equal(0, test.Count);
            Assert.Null(test[0]);
            Assert.Null(test[1]);
            Assert.Null(test[2]);
            Assert.Null(test[3]);
        }

        [Fact]
        public void ValidatesAddMethod()
        {
            var test = new ObjArrayCollection();
            test.Add("Abc");
            test.Add(3.02);
            test.Add('E');
            test.Add(6);
            test.Add(7);
            Assert.Equal("Abc", test[0]);
            Assert.Equal(3.02, test[1]);
            Assert.Equal('E', test[2]);
            Assert.Equal(6, test[3]);
            Assert.Equal(7, test[4]);
        }

        [Fact]
        public void ValidatesCountMethod()
        {
            var test = new ObjArrayCollection();
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
            var test = new ObjArrayCollection();
            test.Add(5);
            test[0] = 'c';
            Assert.Equal('c', test[0]);
        }

        [Fact]
        public void ValidatesContainMethodAndFindsElement()
        {
            var test = new ObjArrayCollection();
            test.Add("Andrei");
            test.Add(3);
            Assert.True(test.Contains("Andrei"));
        }

        [Fact]
        public void ValidatesContainMethodAndDoesNotFindElement()
        {
            var test = new ObjArrayCollection();
            test.Add("Andrei");
            test.Add(3);
            Assert.False(test.Contains(2));
        }

        [Fact]
        public void ValidatesIndexOfMethodAndReturnsIndex()
        {
            var test = new ObjArrayCollection();
            test.Add(5);
            test.Add('b');
            Assert.Equal(1, test.IndexOf('b'));
        }

        [Fact]
        public void ValidatesIndexOfMethodAndDoesNotReturnIndex()
        {
            var test = new ObjArrayCollection();
            test.Add(5);
            test.Add('b');
            Assert.Equal(-1, test.IndexOf(1000));
        }

        [Fact]
        public void ValidatesInsertMethod()
        {
            var test = new ObjArrayCollection();
            test.Add(5);
            test.Add(3);
            test.Insert(0, "abc");
            Assert.Equal("abc", test[0]);
            Assert.Equal(5, test[1]);
            Assert.Equal(3, test[2]);
            Assert.Equal(3, test.Count);
        }

        [Fact]
        public void ValidatesClearMethod()
        {
            var test = new ObjArrayCollection { 5, 3 };

            test.Clear();
            Assert.Equal(0, test.Count);
        }

        [Fact]
        public void ValidatesRemoveMethod()
        {
            var test = new ObjArrayCollection();
            test.Add(5);
            test.Add(3);
            test.Remove(5);
            Assert.Equal(3, test[0]);
        }

        [Fact]
        public void ValidatesRemoveAtMethod()
        {
            var test = new ObjArrayCollection();
            test.Add(5);
            test.Add(3);
            test.RemoveAt(0);
            Assert.Equal(3, test[0]);
        }
    }
}
