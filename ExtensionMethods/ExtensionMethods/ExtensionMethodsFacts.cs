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

        [Fact]
        public void OrderByOrdersIntegerArrayAscending()
        {
            int[] testArray = new[] { 3, 2, 1 };
            Assert.Equal(new[] { 1, 2, 3 }, testArray.OrderBy(digit => digit, new IntegerComparer()));
        }

        [Fact]
        public void ThenByOrdersByOrdinalAfterOrderingByLength()
        {
            string[] testArray = new[] { "baa", "caa", "a", "ac", "ab" };
            Assert.Equal(new[] { "a", "ab", "ac", "baa", "caa" }, testArray.OrderBy(word => word.Length, new IntegerComparer())
                .ThenBy(word => word, StringComparer.Ordinal));
        }

        [Fact]
        public void AllThrowsNullSourceException()
        {
            List<int> test = null;
            Assert.Throws<ArgumentNullException>(() => test.All(element => element % 2 == 1));
        }

        [Fact]
        public void AllThrowsNullPredicateException()
        {
            List<int> test = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => test.All(null));
        }

        [Fact]
        public void AnyThrowsNullSourceException()
        {
            List<int> test = null;
            Assert.Throws<ArgumentNullException>(() => test.Any(element => element % 2 == 1));
        }

        [Fact]
        public void AnyThrowsNullPredicateException()
        {
            List<int> test = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => test.Any(null));
        }

        [Fact]
        public void FirstThrowsNullSourceException()
        {
            List<int> test = null;
            Assert.Throws<ArgumentNullException>(() => test.First(element => element % 2 == 1));
        }

        [Fact]
        public void FirstThrowsNullPredicateException()
        {
            List<int> test = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => test.First(null));
        }

        [Fact]
        public void SelectThrowsNullSourceException()
        {
            int[] array = null;
            var enumerator = array.Select(n => n * 2).GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => enumerator.MoveNext());
        }

        [Fact]
        public void SelectThrowsNullSelectorException()
        {
            var array = new[] { 1, 2, 3, 4 };
            var enumerator = array.Select<int, int>(null).GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => enumerator.MoveNext());
        }

        [Fact]
        public void SelectManyThrowsNullSourceException()
        {
            IEnumerable<string> list = null;
            var result = list.SelectMany(element => new List<string> { element.ToLower() }).GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => result.MoveNext());
        }

        [Fact]
        public void SelectManyThrowsNullSelectorException()
        {
            string[] list = new[] { "abc", "cde", "efg" };
            var result = list.SelectMany<string, string>(null).GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => result.MoveNext());
        }

        [Fact]
        public void WhereThrowsNullPredicateException()
        {
            string[] list = new[] { "abc", "cde", "efg" };
            var result = list.Where(null).GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => result.MoveNext());
        }

        [Fact]
        public void WhereThrowsNullSourceException()
        {
            string[] list = null;
            var result = list.Where(word => word[0] == 'a').GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => result.MoveNext());
        }

        [Fact]
        public void ToDictionaryThrowsNullSourceException()
        {
            string[] list = null;
            Assert.Throws<ArgumentNullException>(() => list.ToDictionary(
                word => word,
                word => word[0]));
        }

        [Fact]
        public void ToDictionaryThrowsNullKeySelectorException()
        {
            string[] list = new[] { "abc", "ced" };
            Assert.Throws<ArgumentNullException>(() => list.ToDictionary<string, string, char>(
                null,
                word => word[0]));
        }

        [Fact]
        public void ToDictionaryThrowsNullElementSelectorException()
        {
            string[] list = new[] { "abc", "ced" };
            Assert.Throws<ArgumentNullException>(() => list.ToDictionary<string, string, string>(
                word => word,
                null));
        }

        [Fact]
        public void ZipThrowsNullSourceExceptionForFirstSource()
        {
            List<int> firstList = null;
            List<int> secondList = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => firstList.Zip(secondList, (first, second) => first * second).GetEnumerator().MoveNext());
        }

        [Fact]
        public void ZipThrowsNullSourceExceptionForSecondSource()
        {
            List<int> firstList = new List<int>() { 1, 2, 3 };
            List<int> secondList = null;
            Assert.Throws<ArgumentNullException>(() => firstList.Zip(secondList, (first, second) => first * second).GetEnumerator().MoveNext());
        }

        [Fact]
        public void ZipThrowsNullSelectorException()
        {
            List<int> firstList = new List<int>() { 1, 2, 3 };
            List<int> secondList = new List<int>() { 2, 3, 4 };
            Assert.Throws<ArgumentNullException>(() => firstList.Zip<int, int, int>(secondList, null).GetEnumerator().MoveNext());
        }

        [Fact]
        public void AggregateThrowsNullSelectorException()
        {
            List<int> testList = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => testList.Aggregate(0, null));
        }

        [Fact]
        public void AggregateThrowsNullSourceException()
        {
            List<int> testList = null;
            Assert.Throws<ArgumentNullException>(() => testList.Aggregate(0, (result, element) => element % 2 != 0 ? result + 1 : result));
        }

        [Fact]
        public void DistinctThrowsNullSourceException()
        {
            List<int> testList = null;
            Assert.Throws<ArgumentNullException>(() => testList.Distinct(new ItemComparer<int>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void JoinThrowsFirstSourceNullException()
        {
            const string firstWord = null;
            const string secondWord = "Ana";
            Assert.Throws<ArgumentNullException>(() => firstWord.Join(
                secondWord,
                firstLetters => firstLetters,
                secondLetters => secondLetters,
                (firstLetters, secondLetters) => firstLetters).GetEnumerator().MoveNext());
        }

        [Fact]
        public void JoinThrowsSecondSourceNullException()
        {
            const string firstWord = "Ana";
            const string secondWord = null;
            Assert.Throws<ArgumentNullException>(() => firstWord.Join(
                secondWord,
                firstLetters => firstLetters,
                secondLetters => secondLetters,
                (firstLetters, secondLetters) => firstLetters).GetEnumerator().MoveNext());
        }

        [Fact]
        public void JoinThrowsFirstSelectorNullException()
        {
            const string firstWord = "Ana";
            const string secondWord = "Inna";
            Assert.Throws<ArgumentNullException>(() => firstWord.Join(
                secondWord,
                null,
                secondLetters => secondLetters,
                (firstLetters, secondLetters) => firstLetters).GetEnumerator().MoveNext());
        }

        [Fact]
        public void JoinThrowsSecondSelectorNullException()
        {
            const string firstWord = "Ana";
            const string secondWord = "Inna";
            Assert.Throws<ArgumentNullException>(() => firstWord.Join(
                secondWord,
                firstLetters => firstLetters,
                null,
                (firstLetters, secondLetters) => firstLetters).GetEnumerator().MoveNext());
        }

        [Fact]
        public void JoinThrowsResultSelectorNullException()
        {
            const string firstWord = "Ana";
            const string secondWord = "Inna";
            Func<char, char, char> nullFunc = null;
            Assert.Throws<ArgumentNullException>(() => firstWord.Join(
                secondWord,
                firstLetters => firstLetters,
                secondWord => secondWord,
                nullFunc).GetEnumerator().MoveNext());
        }

        [Fact]
        public void UnionThrowsFirstSourceNullException()
        {
            int[] firstArray = null;
            int[] secondArray = { 8, 3, 6, 4, 4, 9, 1, 0 };
            Assert.Throws<ArgumentNullException>(() => firstArray.Union(secondArray, new ItemComparer<int>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void UnionThrowsSecondSourceNullException()
        {
            int[] firstArray = { 5, 3, 9, 7, 5, 9, 3, 7 };
            int[] secondArray = null;
            Assert.Throws<ArgumentNullException>(() => firstArray.Union(secondArray, new ItemComparer<int>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void IntersectThrowsFirstSourceNullException()
        {
            int[] firstArray = null;
            int[] secondArray = { 8, 3, 6, 4 };
            Assert.Throws<ArgumentNullException>(() => firstArray.Intersect(secondArray, new ItemComparer<int>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void IntersectThrowsSecondSourceNullException()
        {
            int[] firstArray = { 5, 3, 9, 4 };
            int[] secondArray = null;
            Assert.Throws<ArgumentNullException>(() => firstArray.Intersect(secondArray, new ItemComparer<int>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void ExceptThrowsFirstSourceNullException()
        {
            int[] firstArray = null;
            int[] secondArray = { 5, 3, 9, 4 };
            Assert.Throws<ArgumentNullException>(() => firstArray.Except(secondArray, new ItemComparer<int>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void ExceptThrowsSecondSourceNullException()
        {
            int[] firstArray = { 5, 3, 9, 4 };
            int[] secondArray = null;
            Assert.Throws<ArgumentNullException>(() => firstArray.Except(secondArray, new ItemComparer<int>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void GroupByThrowsNullResultSelectorException()
        {
            string[] testArray = { "Many:1", "Dan:2", "math:3", "rose:1" };
            Assert.Throws<ArgumentNullException>(() => testArray.GroupBy<string, string, string, string>(
               key => key.Split(':')[1],
               value => value.Split(':')[0],
               null,
               new ItemComparer<string>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void GroupByThrowsNullElementSelectorException()
        {
            string[] testArray = { "Many:1", "Dan:2", "math:3", "rose:1" };
            Assert.Throws<ArgumentNullException>(() => testArray.GroupBy<string, string, string, string>(
               key => key.Split(':')[1],
               null,
               (_, values) => string.Join(",", values),
               new ItemComparer<string>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void GroupByThrowsNullSourceException()
        {
            string[] testArray = null;
            Assert.Throws<ArgumentNullException>(() => testArray.GroupBy(
               key => key.Split(':')[1],
               value => value.Split(':')[0],
               (_, values) => string.Join(",", values),
               new ItemComparer<string>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void GroupByThrowsNullKeySelectorException()
        {
            string[] testArray = { "Many:1", "Dan:2", "math:3", "rose:1" };
            Assert.Throws<ArgumentNullException>(() => testArray.GroupBy(
              null,
              value => value.Split(':')[0],
              (_, values) => string.Join(",", values),
              new ItemComparer<string>()).GetEnumerator().MoveNext());
        }

        [Fact]
        public void OrderByThrowsNullSourceException()
        {
            int[] testArray = null;
            Assert.Throws<ArgumentNullException>(() => testArray.OrderBy(digit => digit, new IntegerComparer()));
        }

        [Fact]
        public void OrderByThrowsNullSelectorException()
        {
            int[] testArray = new[] { 3, 2, 1 };
            Assert.Throws<ArgumentNullException>(() => testArray.OrderBy(null, new IntegerComparer()));
        }

        [Fact]
        public void ThenByThrowsNullSourceException()
        {
            string[] testArray = null;
            Assert.Throws<ArgumentNullException>(() => testArray.OrderBy(word => word.Length, new IntegerComparer())
                .ThenBy(word => word, StringComparer.Ordinal));
        }

        [Fact]
        public void ThenByThrowsNullSelectorException()
        {
            string[] testArray = new[] { "baa", "caa", "a", "ac", "ab" };
            Assert.Throws<ArgumentNullException>(() => testArray.OrderBy(word => word.Length, new IntegerComparer())
                .ThenBy(null, StringComparer.Ordinal));
        }

        internal class IntegerComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }
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
