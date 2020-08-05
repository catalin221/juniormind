using Xunit;

namespace DataStructures
{
    public class LinkedListCollectionTests
    {
        [Fact]
        public void ValidateImplicitConstructor()
        {
            var list = new LinkedListCollection<int>();
            Assert.Equal(list.Sentinel, list.Sentinel.Next);
            Assert.Equal(list.Sentinel, list.Sentinel.Previous);
        }

        [Fact]
        public void ValidateConstructorWithGivenArray()
        {
            int[] array = new[] { 1, 2, 3, 4 };
            var list = new LinkedListCollection<int>(array);
            Assert.Equal(1, list.Sentinel.Next.Value);
            Assert.Equal(4, list.Sentinel.Previous.Value);
            LinkedListNode<int> current = list.Sentinel;
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
            Assert.Equal(2, list.Sentinel.Next.Value);
        }

        [Fact]
        public void ValidatesAddLastMethodForListWithElements()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3 });
            list.Add(4);
            Assert.Equal(4, list.Sentinel.Previous.Value);
        }

        [Fact]
        public void ValidatesAddFirstMethodForEmptyList()
        {
            var list = new LinkedListCollection<int>();
            list.AddFirst(4);
            Assert.Equal(4, list.Sentinel.Next.Value);
        }

        [Fact]
        public void ValidatesAddFirstMethodForListWithElements()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3 });
            list.AddFirst(4);
            Assert.Equal(4, list.Sentinel.Next.Value);
        }

        [Fact]
        public void ValidatesRemoveFirstMethod()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3 });
            list.RemoveFirst();
            Assert.Equal(2, list.Sentinel.Next.Value);
        }

        [Fact]
        public void ValidatesRemoveLastMethod()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3 });
            list.RemoveLast();
            Assert.Equal(2, list.Sentinel.Previous.Value);
        }

        [Fact]

        public void ValidatesRemoveMethod()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3 });
            Assert.True(list.Remove(2));
            Assert.Equal(1, list.Sentinel.Next.Value);
            Assert.Equal(3, list.Sentinel.Previous.Value);
        }

        [Fact]

        public void ValidatesFindFirstMethod()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3 });
            Assert.Equal(list.Sentinel.Next, list.Find(1));
        }

        [Fact]

        public void ValidatesFindLastMethod()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3, 4, 5 });
            LinkedListNode<int> current = list.Sentinel.Previous.Previous;
            Assert.Equal(current, list.Find(4));
        }

        [Fact]

        public void ValidatesCointainsMethod()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3 });
            Assert.Contains(2, list);
        }

        [Fact]

        public void ValidatesClearMethod()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3 });
            list.Clear();
            Assert.Empty(list);
        }

        [Fact]

        public void ValidatesCopyToMethod()
        {
            var list = new LinkedListCollection<int>(new[] { 1, 2, 3 });
            var array = new int[3];
            list.CopyTo(array, 0);
            LinkedListNode<int> node = list.Sentinel.Next;
            foreach (var x in array)
            {
                Assert.Equal(x, node.Value);
                node = node.Next;
            }
        }
    }
}
