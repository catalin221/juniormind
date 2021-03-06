﻿using Xunit;

namespace DataStructures
{
    public class SortedIntegerArrayTests
    {
        [Fact]
        public void ValidatesConstructor()
        {
            var test = new SortedIntArray();
            Assert.Equal(0, test.Count);
            Assert.Equal(0, test[0]);
            Assert.Equal(0, test[1]);
            Assert.Equal(0, test[2]);
            Assert.Equal(0, test[3]);
        }

        [Fact]
        public void ValidatesAddMethod()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            test.Add(2);
            test.Add(6);
            test.Add(7);
            Assert.Equal(2, test[0]);
            Assert.Equal(3, test[1]);
            Assert.Equal(5, test[2]);
            Assert.Equal(6, test[3]);
            Assert.Equal(7, test[4]);
        }

        [Fact]
        public void ValidatesCountMethod()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            test.Add(2);
            test.Add(6);
            test.Add(7);
            Assert.Equal(5, test.Count);
        }

        [Fact]
        public void ValidatesSetElementMethodOnFirstIndex()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(1);
            test[0] = 6;
            Assert.Equal(1, test[0]);
        }

        [Fact]
        public void ValidatesSetElementForLastIndex()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(1);
            test.Add(4);
            test[2] = 6;
            Assert.Equal(6, test[2]);
        }

        [Fact]
        public void ValidatesSetElementForAnyIndex()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(1);
            test.Add(4);
            test.Add(2);
            test[1] = 3;
            Assert.Equal(3, test[1]);
        }

        [Fact]
        public void DoesNotSetElementThatChangesOrder()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(1);
            test.Add(4);
            test.Add(2);
            test[1] = 5;
            Assert.Equal(2, test[1]);
        }

        [Fact]
        public void ValidatesContainMethodAndFindsElement()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            Assert.True(test.Contains(3));
        }

        [Fact]
        public void ValidatesContainMethodAndDoesNotFindElement()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            Assert.False(test.Contains(2));
        }

        [Fact]
        public void ValidatesIndexOfMethodAndReturnsIndex()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            Assert.Equal(0, test.IndexOf(3));
        }

        [Fact]
        public void ValidatesIndexOfMethodAndDoesNotReturnIndex()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            Assert.Equal(-1, test.IndexOf(1000));
        }

        [Fact]
        public void ValidatesInsertMethod()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            test.Insert(0, 4);
            Assert.Equal(3, test[0]);
            Assert.Equal(5, test[1]);
            Assert.Equal(2, test.Count);
        }

        [Fact]
        public void ValidatesInsertMethodWhereMoreElementsAreEqual()
        {
            var test = new SortedIntArray();
            test.Add(3);
            test.Add(5);
            test.Add(3);
            test.Add(2);
            test.Add(2);

            test.Insert(2, 2);
            Assert.Equal(2, test[0]);
            Assert.Equal(2, test[1]);
            Assert.Equal(2, test[2]);
            Assert.Equal(3, test[3]);
            Assert.Equal(3, test[4]);
            Assert.Equal(5, test[5]);

            Assert.Equal(6, test.Count);
        }

        [Fact]
        public void DoesNotInsertBadElement()
        {
            var test = new SortedIntArray();
            test.Add(3);
            test.Add(5);
            test.Add(3);
            test.Add(2);
            test.Add(2);

            test.Insert(2, 5);
            Assert.Equal(2, test[0]);
            Assert.Equal(2, test[1]);
            Assert.Equal(3, test[2]);
            Assert.Equal(3, test[3]);
            Assert.Equal(5, test[4]);

            Assert.Equal(5, test.Count);
        }

        [Fact]
        public void ValidatesInsertMethodAndInsertsAnElement()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            test.Insert(0, 1);
            Assert.Equal(1, test[0]);
            Assert.Equal(3, test[1]);
            Assert.Equal(5, test[2]);
            Assert.Equal(3, test.Count);
        }

        [Fact]
        public void ValidatesClearMethod()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            test.Clear();
            Assert.Equal(0, test.Count);
        }

        [Fact]
        public void ValidatesRemoveMethod()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            test.Remove(5);
            Assert.Equal(3, test[0]);
        }

        [Fact]
        public void ValidatesRemoveAtMethod()
        {
            var test = new SortedIntArray();
            test.Add(5);
            test.Add(3);
            test.RemoveAt(0);
            Assert.Equal(5, test[0]);
        }
    }
}