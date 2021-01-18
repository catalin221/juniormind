using Xunit;

namespace LinqApplications
{
    public class NumbersFiletringFacts
    {
        [Fact]
        public void GenerateSubsetsGeneratesSubsetsOfGivenSum()
        {
            var set = new[] { 1, 2, 3, 4, 5, 6 };
            Assert.Equal(new[] { new[] { 4 }, new[] { 3 }, new[] { 1, 2 }, new[] { 2 }, new[] { 1 } }, NumbersFiltering.GetSubsetsOfSpecificSum(set, 4));
        }
    }
}
