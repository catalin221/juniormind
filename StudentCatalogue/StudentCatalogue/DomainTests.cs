using Xunit;

namespace StudentCatalogue
{
    public class DomainTests
    {
        [Fact]
        public void CheckForWorkingConstructor()
        {
            Domain testDomain = new Domain("Math", 9.00);
            Assert.True(testDomain.MatchDomain("Math") && testDomain.MatchGrade(9.00));
        }

        [Fact]

        public void CheckIfNewGradeIsAdded()
        {
            Domain testDomain = new Domain("Math", 9.00);
            testDomain.AddNewGrade(6.33);
            Assert.True(testDomain.MatchGrade(6.33));
        }
    }
}
