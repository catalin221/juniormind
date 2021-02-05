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

        [Fact]
        public void GenerateSumSetsGeneratesSetsOfSumK()
        {
            var sum = NumbersFiltering.GenerateSumSets(6, 11);
            Assert.Equal(
                new[]
            {
                 "+1+2+3+4-5+6 = 11",
                 "+1-2-3+4+5+6 = 11",
                 "-1+2+3-4+5+6 = 11"
            }, sum);
        }

        [Fact]
        public void GeneratePythagoreanTriplesGeneratesPythagoreanSubsets()
        {
            var set = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.Equal(new[] { new[] { 3, 4, 5 }, new[] { 4, 3, 5 } }, NumbersFiltering.GeneratePythagoreanTriples(set));
        }
    }
}
