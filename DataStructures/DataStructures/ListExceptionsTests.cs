using Xunit;
using System;

namespace DataStructures
{
    public class ListExceptionsTests
    {
        [Fact]
        public void IndexerSetMethodOutOfRangeException()
        {
            var testList = new ListCollection<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => testList[-1] = 1);
        }

        [Fact]
        public void IndexerSetMethodIsReadonlyException()
        {
            var testList = new ListCollection<int> { 1, 2 };
            testList = testList.ReadOnlyList();
            Assert.Throws<NotSupportedException>(() => testList[0] = 2);
        }

        [Fact]
        public void IndexerGetMethodOutOfRangeException()
        {
            var testList = new ListCollection<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => testList[-1] == 1);
        }

        [Fact]
        public void AddMethodIsReadonlyException()
        {
            var testList = new ListCollection<int> { 1, 2 };
            testList = testList.ReadOnlyList();
            Assert.Throws<NotSupportedException>(() => testList.Add(2));
        }

        [Fact]
        public void ClearMethodIsReadonlyException()
        {
            var testList = new ListCollection<int> { 1, 2 };
            testList = testList.ReadOnlyList();
            Assert.Throws<NotSupportedException>(() => testList.Clear());
        }

        [Fact]
        public void InsertMethodIsReadonlyException()
        {
            var testList = new ListCollection<int> { 1, 2 };
            testList = testList.ReadOnlyList();
            Assert.Throws<NotSupportedException>(() => testList.Insert(1, 2));
        }

        [Fact]
        public void CopyToMethodArgumentNullException()
        {
            var testList = new ListCollection<int>();
            int[] testArray = null;
            Assert.Throws<ArgumentNullException>(() => testList.CopyTo(testArray, 0));
        }

        [Fact]
        public void CopyToMethodNegativeIndexException()
        {
            var testList = new ListCollection<int>();
            int[] testArray = new int[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.CopyTo(testArray, -1));
        }

        [Fact]
        public void CopyToMethodArgumentException()
        {
            var testList = new ListCollection<int>();
            int[] testArray = new int[4];
            Assert.Throws<ArgumentException>(() => testList.CopyTo(testArray, 2));
        }

        [Fact]
        public void InsertMethodOutOfBoundsException()
        {
            var testList = new ListCollection<int>();
            int[] testArray = new int[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.Insert(-3, 4));
        }

        [Fact]
        public void RemoveAtMethodOutOfBoundsException()
        {
            var testList = new ListCollection<int>();
            int[] testArray = new int[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.RemoveAt(-2));
        }
    }
}
