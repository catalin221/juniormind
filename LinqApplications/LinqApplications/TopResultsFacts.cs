using Xunit;
using System.Collections.Generic;

namespace LinqApplications
{
    public class TopResultsFacts
    {
        [Fact]
        public void GetMaxPerFamilyReturnsListWithMaximumResultOfFamily()
        {
            var firstResult = new TestResults(id: "Ionescu", familyId: "I", score: 10);
            var secondResult = new TestResults(id: "Ionescu", familyId: "I", score: 15);
            var testList = new List<TestResults> { firstResult, secondResult };
            Assert.Equal(new List<TestResults> { new TestResults("Ionescu", "I", 15) }, TopResult.GetMaxPerFamily(testList));
        }
    }
}
