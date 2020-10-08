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
    }
}
