using Xunit;
using System;

namespace DataStructures
{
    public class LinkedListCollectionExceptionsTests
    {
        [Fact]
        public void ArrayForConstructorIsNullException()
        {
            int[] testArray = null;
            Assert.Throws<ArgumentNullException>(() => new LinkedListCollection<int>(testArray));
        }

        [Fact]
        public void IsReadOnlyAddMethodException()
        {
            var test = new LinkedListCollection<int>();
            test.Add(1);
            test.Add(2);
            test = test.ReadOnlyList();
            Assert.Throws<NotSupportedException>(() => test.Add(3));
        }

        [Fact]
        public void NullNodeAddMethodException()
        {
            var test = new LinkedListCollection<int> { 1, 2 };
            LinkedListNode<int> testNode = null;
            Assert.Throws<ArgumentNullException>(() => test.Add(testNode));
        }

        [Fact]
        public void NullItemAddMethodException()
        {
            var test = new LinkedListCollection<int?> { 1, 2 };
            int? testNode = null;
            Assert.Throws<ArgumentNullException>(() => test.Add(testNode));
        }

        [Fact]
        public void AlreadyInListAddMethodException()
        {
            var test = new LinkedListCollection<int?> { 1, 2 };
            const int testNode = 2;
            Assert.Throws<InvalidOperationException>(() => test.Add(testNode));
        }

        [Fact]
        public void AlreadyInListAddFirstMethodException()
        {
            var test = new LinkedListCollection<int?> { 1, 2 };
            const int testNode = 2;
            Assert.Throws<InvalidOperationException>(() => test.AddFirst(testNode));
        }

        [Fact]
        public void NullItemAddFirstMethodException()
        {
            var test = new LinkedListCollection<int?> { 1, 2 };
            int? testNode = null;
            Assert.Throws<ArgumentNullException>(() => test.AddFirst(testNode));
        }

        [Fact]
        public void NullNodeAddFirstMethodException()
        {
            var test = new LinkedListCollection<int> { 1, 2 };
            LinkedListNode<int> testNode = null;
            Assert.Throws<ArgumentNullException>(() => test.AddFirst(testNode));
        }

        [Fact]
        public void IsReadOnlyAddFirstMethodException()
        {
            var test = new LinkedListCollection<int>();
            test.Add(1);
            test.Add(2);
            test = test.ReadOnlyList();
            Assert.Throws<NotSupportedException>(() => test.AddFirst(3));
        }

        [Fact]
        public void ArrayNullCopyToMethodException()
        {
            var test = new LinkedListCollection<int>();
            int[] testArray = null;
            test.Add(1);
            test.Add(2);
            Assert.Throws<ArgumentNullException>(() => test.CopyTo(testArray, 0));
        }

        [Fact]
        public void NegativeIndexCopyToMethodException()
        {
            var test = new LinkedListCollection<int>();
            int[] testArray = new int[4];
            test.Add(1);
            test.Add(2);
            Assert.Throws<ArgumentOutOfRangeException>(() => test.CopyTo(testArray, -1));
        }

        [Fact]
        public void ArgumentExceptionCopyToMethodException()
        {
            var test = new LinkedListCollection<int>();
            int[] testArray = new int[4];
            test.Add(1);
            test.Add(2);
            test.Add(3);
            Assert.Throws<ArgumentException>(() => test.CopyTo(testArray, 2));
        }

        [Fact]
        public void IsReadOnlyRemoveMethodException()
        {
            var test = new LinkedListCollection<int>();
            test.Add(1);
            test.Add(2);
            test = test.ReadOnlyList();
            Assert.Throws<NotSupportedException>(() => test.Remove(2));
        }

        [Fact]
        public void IsReadOnlyClearMethodException()
        {
            var test = new LinkedListCollection<int>();
            test.Add(1);
            test.Add(2);
            test = test.ReadOnlyList();
            Assert.Throws<NotSupportedException>(() => test.Clear());
        }
    }
}