using Xunit;
using System;

namespace DataStructures
{
    public class ListExceptionsTests
    {
        [Fact]
        public void IndexerSetMethodOutOfRangeException()
        {
            var testList = new List<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => testList[-1] = 1);
        }

        [Fact]
        public void IndexerGetMethodOutOfRangeException()
        {
            var testList = new List<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => testList[-1] == 1);
        }

        [Fact]
        public void CopyToMethodArgumentNullException()
        {
            var testList = new List<int>();
            int[] testArray = null;
            Assert.Throws<ArgumentNullException>(() => testList.CopyTo(testArray, 0));
        }

        [Fact]
        public void CopyToMethodNegativeIndexException()
        {
            var testList = new List<int>();
            int[] testArray = new int[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.CopyTo(testArray, -1));
        }

        [Fact]
        public void CopyToMethodArgumentException()
        {
            var testList = new List<int>();
            int[] testArray = new int[4];
            Assert.Throws<ArgumentException>(() => testList.CopyTo(testArray, 2));
        }

        [Fact]
        public void InsertMethodOutOfBoundsException()
        {
            var testList = new List<int>();
            int[] testArray = new int[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.Insert(-3, 4));
        }

        [Fact]
        public void RemoveAtMethodOutOfBoundsException()
        {
            var testList = new List<int>();
            int[] testArray = new int[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.RemoveAt(-2));
        }
    }
}
