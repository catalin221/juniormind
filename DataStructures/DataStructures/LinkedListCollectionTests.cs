using Xunit;

namespace DataStructures
{
    public class LinkedListCollectionTests
    {
        [Fact]
        public void ValidateImplicitConstructor()
        {
            var list = new LinkedListCollection<int>();
            Assert.Empty(list);
        }

        [Fact]
        public void ValidateConstructorWithGivenArray()
        {
            int[] array = new[] { 1, 2, 3, 4 };
            var list = new LinkedListCollection<int>(array);
            Assert.Equal(1, list.GetFirst.Value);
            Assert.Equal(4, list.GetLast.Value);
            LinkedListNode<int> current = list.GetFirst;
            foreach (int digit in array)
            {
                Assert.Equal(digit, current.Value);
                current = current.Next;
            }
        }

        [Fact]
        public void ValidatesAddLastMethodForEmptyList()
        {
            var list = new LinkedListCollection<int>();
            list.Add(2);
            Assert.Equal(2, list.GetFirst.Value);
        }

        [Fact]
        public void ValidatesAddLastMethodForListWithElements()
        {
            var list = new LinkedListCollection<int> { 1, 2, 2, 3 };
            list.Add(4);
            Assert.Equal(4, list.GetLast.Value);
        }

        [Fact]
        public void ValidatesAddBeforeMethod()
        {
            var list = new LinkedListCollection<int> { 1, 2, 4 };
            list.AddBefore(list.GetLast, 3);
            Assert.Equal(3, list.GetLast.Previous.Value);
        }

        [Fact]
        public void ValidatesAddAfterMethod()
        {
            var list = new LinkedListCollection<int> { 1, 3, 4 };
            list.AddAfter(list.GetFirst, 2);
            Assert.Equal(2, list.GetFirst.Next.Value);
        }

        [Fact]
        public void ValidatesAddFirstMethodForEmptyList()
        {
            var list = new LinkedListCollection<int>();
            list.AddFirst(4);
            Assert.Equal(4, list.GetFirst.Value);
        }

        [Fact]
        public void ValidatesAddFirstMethodForListWithElements()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3 };
            list.AddFirst(4);
            Assert.Equal(4, list.GetFirst.Value);
        }

        [Fact]
        public void ValidatesRemoveFirstMethod()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3 };
            list.RemoveFirst();
            Assert.Equal(2, list.GetFirst.Value);
        }

        [Fact]
        public void ValidatesRemoveLastMethod()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3 };
            list.RemoveLast();
            Assert.Equal(2, list.GetLast.Value);
        }

        [Fact]

        public void ValidatesRemoveMethod()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3 };
            Assert.True(list.Remove(2));
            Assert.Equal(1, list.GetFirst.Value);
            Assert.Equal(3, list.GetLast.Value);
        }

        [Fact]
        public void ValidatesRemoveMethodThatReturnsFalse()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3 };
            Assert.False(list.Remove(4));
        }

        [Fact]

        public void ValidatesFindFirstMethod()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3 };
            Assert.Equal(list.GetFirst, list.Find(1));
        }

        [Fact]

        public void ValidatesFindLastMethod()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3, 4, 5 };
            Assert.Equal(list.GetLast.Previous, list.Find(4));
        }

        [Fact]

        public void ValidatesCointainsMethod()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3 };
            Assert.Contains(2, list);
        }

        [Fact]

        public void ValidatesClearMethod()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3 };
            list.Clear();
            Assert.Empty(list);
        }

        [Fact]

        public void ValidatesCopyToMethod()
        {
            var list = new LinkedListCollection<int> { 1, 2, 3 };
            var array = new int[3];
            list.CopyTo(array, 0);
            LinkedListNode<int> node = list.GetFirst;
            foreach (var x in array)
            {
                Assert.Equal(x, node.Value);
                node = node.Next;
            }
        }
    }
}
