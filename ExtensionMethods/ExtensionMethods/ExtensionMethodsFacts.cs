using System;
using System.Collections.Generic;
using Xunit;

namespace ExtensionMethods
{
    public class ExtensionMethodsFacts
    {
        [Fact]
        public void All_Method_Returns_True_Odd_Elements_Test()
        {
            List<int> testList = new List<int> { 1, 3, 5, 7 };
            Assert.True(testList.All(element => element % 2 == 1));
        }

        [Fact]
        public void All_Method_Returns_False_Odd_Elements_Test()
        {
            List<int> testList = new List<int> { 1, 2, 5, 7 };
            Assert.False(testList.All(element => element % 2 == 1));
        }

        [Fact]
        public void Any_Method_Returns_False_Odd_Elements_Test()
        {
            List<int> testList = new List<int> { 4, 4, 6, 8 };
            Assert.False(testList.Any(element => element % 2 == 1));
        }

        [Fact]
        public void Any_Method_Returns_True_Odd_Elements_Test()
        {
            List<int> testList = new List<int> { 2, 2, 4, 7 };
            Assert.True(testList.Any(element => element % 2 == 1));
        }

        [Fact]
        public void First_Method_Odd_Elements_Throws_Exception()
        {
            List<int> testList = new List<int> { 2, 2, 4, 6 };
            Assert.Throws<InvalidOperationException>(() => testList.First(element => element % 2 == 1));
        }

        [Fact]
        public void First_Method_Finds_Odd_Element()
        {
            List<int> testList = new List<int> { 2, 2, 4, 7 };
            Assert.Equal(7, testList.First(element => element % 2 == 1));
        }

        [Fact]
        public void Select_Method_Square_Elements()
        {
            List<int> testList = new List<int> { 2, 3, 4, 5 };
            IEnumerable<int> squareList = new List<int> { 4, 9, 16, 25 };
            IEnumerable<int> resultList = testList.Select(element => element * element);
            Assert.Equal(squareList, resultList);
        }

        [Fact]
        public void SelectMany_Method_Returns_All_Items_To_Lower()
        {
            List<string> names = new List<string>(new [] { "John", "Alan", "Greg" });
            IEnumerable<string> resultList = names.SelectMany(element => new List<string> { element.ToLower()});
            Assert.Equal(new[] { "john", "alan", "greg" }, resultList);
        }

        [Fact]
        public void Where_Method_Returns_Numbers_With_Specific_Digit()
        {
            List<int> number = new List<int>() { 23, 47, 52, 26 };
            Assert.Equal(new List<int> { 23, 52, 26 }, number.Where(element => element.ToString().Contains('2')));
        }

        [Fact]
        public void Where_Method_Returns_No_Numbers_With_Specific_Digit()
        {
            List<int> number = new List<int>() { 23, 47, 52, 26 };
            Assert.Equal(new List<int> { }, number.Where(element => element.ToString().Contains('8')));
        }

        [Fact]
        public void ToDictionary_Key_Is_Value_ToString()
        {
            List<int> number = new List<int>() { 23, 47, 52, 26 };
            Dictionary<string, int> dictionaryTest = number.ToDictionary(element => element.ToString(), element => element);
            Assert.Equal(new Dictionary<string, int>() { { "23", 23 }, { "47", 47 }, { "52", 52 }, { "26", 26 } }, dictionaryTest);
        }

        [Fact]
        public void Zip_Returns_List_With_Product_Of_Integer_Lists()
        {
            List<int> firstList = new List<int>() { 2, 4, 5 };
            List<int> secondList = new List<int>() { 1, 2, 3 };
            Assert.Equal(new List<int> {2, 8, 15 }, firstList.Zip(secondList, (first, second) => first * second));
        }

        [Fact]
        public void Aggregate_Returns_Number_Of_Elements_With_Specific_Digit()
        {
            List<int> number = new List<int>() { 23, 47, 52, 26 };
            Assert.Equal(3, number.Aggregate(0, (total, element) => element.ToString().Contains('2') ? total + 1 : total));
        }
    }
}
