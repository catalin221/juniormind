using Xunit;
using System.Collections.Generic;

namespace LinqApplications
{
    public class ListConjunctionFacts
    {
        [Fact]
        public void ListUnionAssemblesTwoListsWithSameProducts()
        {
            var firstList = new List<Product> { new Product("apple", 5), new Product("orange", 5) };
            var secondList = new List<Product> { new Product("apple", 4), new Product("orange", 2) };
            Assert.Equal(new List<Product> { new Product("apple", 9), new Product("orange", 7) }, ListConjunction.ListUnion(firstList, secondList));
        }
    }
}
