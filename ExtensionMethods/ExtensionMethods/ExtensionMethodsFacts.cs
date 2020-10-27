using System;
using System.Collections.Generic;
using Xunit;

namespace ExtensionMethods
{
    public class ExtensionMethodsFacts
    {
        [Fact]
        public void AllMethodReturnsTrueOddElementsTest()
        {
            List<int> testList = new List<int> { 1, 3, 5, 7 };
            Assert.True(testList.All(element => element % 2 == 1));
        }

        [Fact]
        public void AllMethodReturnsFalseOddElementsTest()
        {
            List<int> testList = new List<int> { 1, 2, 5, 7 };
            Assert.False(testList.All(element => element % 2 == 1));
        }

        [Fact]
        public void AnyMethodReturnsFalseOddElementsTest()
        {
            List<int> testList = new List<int> { 4, 4, 6, 8 };
            Assert.False(testList.Any(element => element % 2 == 1));
        }

        [Fact]
        public void AnyMethodReturnsTrueOddElementsTest()
        {
            List<int> testList = new List<int> { 2, 2, 4, 7 };
            Assert.True(testList.Any(element => element % 2 == 1));
        }

        [Fact]
        public void FirstMethodOddElementsThrowsException()
        {
            List<int> testList = new List<int> { 2, 2, 4, 6 };
            Assert.Throws<InvalidOperationException>(() => testList.First(element => element % 2 == 1));
        }

        [Fact]
        public void FirstMethodFindsOddElement()
        {
            List<int> testList = new List<int> { 2, 2, 4, 7 };
            Assert.Equal(7, testList.First(element => element % 2 == 1));
        }

        [Fact]
        public void SelectMethodSquareElements()
        {
            List<int> testList = new List<int> { 2, 3, 4, 5 };
            IEnumerable<int> squareList = new List<int> { 4, 9, 16, 25 };
            IEnumerable<int> resultList = testList.Select(element => element * element);
            Assert.Equal(squareList, resultList);
        }

        [Fact]
        public void SelectManyMethodReturnsAllItemsToLower()
        {
            List<string> names = new List<string>(new[] { "John", "Alan", "Greg" });
            IEnumerable<string> resultList = names.SelectMany(element => new List<string> { element.ToLower() });
            Assert.Equal(new[] { "john", "alan", "greg" }, resultList);
        }

        [Fact]
        public void WhereMethodReturnsNumbersWithSpecificDigit()
        {
            List<int> number = new List<int>() { 23, 47, 52, 26 };
            Assert.Equal(new List<int> { 23, 52, 26 }, number.Where(element => element.ToString().Contains('2')));
        }

        [Fact]
        public void WhereMethodReturnsNoNumbersWithSpecificDigit()
        {
            List<int> number = new List<int>() { 23, 47, 52, 26 };
            Assert.Equal(new List<int>(), number.Where(element => element.ToString().Contains('8')));
        }

        [Fact]
        public void ToDictionaryKeyIsValueToString()
        {
            List<int> number = new List<int>() { 23, 47, 52, 26 };
            Dictionary<string, int> dictionaryTest = number.ToDictionary(element => element.ToString(), element => element);
            Assert.Equal(new Dictionary<string, int>() { { "23", 23 }, { "47", 47 }, { "52", 52 }, { "26", 26 } }, dictionaryTest);
        }

        [Fact]
        public void ZipReturnsListWithProductOfIntegerLists()
        {
            List<int> firstList = new List<int>() { 2, 4, 5 };
            List<int> secondList = new List<int>() { 1, 2, 3 };
            Assert.Equal(new List<int> { 2, 8, 15 }, firstList.Zip(secondList, (first, second) => first * second));
        }

        [Fact]
        public void AggregateReturnsNumberOfElementsWithSpecificDigit()
        {
            List<int> number = new List<int>() { 23, 47, 52, 26 };
            Assert.Equal(3, number.Aggregate(0, (total, element) => element.ToString().Contains('2') ? total + 1 : total));
        }

        [Fact]
        public void JoinReturnsCommonLetters()
        {
            const string firstWord = "Inna";
            const string secondWord = "Ana";
            var result = firstWord.Join(
                secondWord,
                firstLetters => firstLetters,
                secondLetters => secondLetters,
                (firstLetters, secondLetters) => firstLetters);
            Assert.Equal("nna", result);
        }

        [Fact]
        public void DistinctReturnsDistinctDigits()
        {
            int[] array = { 1, 2, 2, 3, 3, 4, 5 };
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, array.Distinct(new ItemComparer<int>()));
        }

        [Fact]
        public void UnionOfIntegerArraysReturnsUnion()
        {
            int[] firstArray = { 5, 3, 9, 7, 5, 9, 3, 7 };
            int[] secondArray = { 8, 3, 6, 4, 4, 9, 1, 0 };
            Assert.Equal(new[] { 5, 3, 9, 7, 8, 6, 4, 1, 0 }, firstArray.Union(secondArray, new ItemComparer<int>()));
        }

        [Fact]
        public void IntersectReturnsCommonIntegers()
        {
            int[] firstArray = { 5, 3, 9, 4 };
            int[] secondArray = { 8, 3, 6, 4 };
            Assert.Equal(new[] { 3, 4 }, firstArray.Intersect(secondArray, new ItemComparer<int>()));
        }

        [Fact]
        public void ExceptReturnsNotCommonIntegers()
        {
            int[] firstArray = { 5, 3, 9, 4 };
            int[] secondArray = { 8, 3, 6, 4 };
            Assert.Equal(new[] { 5, 9 }, firstArray.Except(secondArray, new ItemComparer<int>()));
        }

        [Fact]
        public void GroupByGroupsWordsWithSameValue()
        {
            string[] testArray = { "Many:1", "Dan:2", "math:3", "rose:1" };
            Assert.Equal(new[] { "Many,rose", "Dan", "math" }, testArray.GroupBy(
               key => key.Split(':')[1],
               value => value.Split(':')[0],
               (_, values) => string.Join(",", values),
               new ItemComparer<string>()));
        }

        class ItemComparer<T> : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                if (x == null && y == null)
                {
                    return true;
                }
                else if (x == null || y == null)
                {
                    return false;
                }
                else if (x.Equals(y))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
