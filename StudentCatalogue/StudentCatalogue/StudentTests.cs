using Xunit;

namespace StudentCatalogue
{
    public class StudentTests
    {
        [Fact]
        public void CheckForWorkingConstructor()
        {
            Domain[] testDomains = new Domain[3];
            testDomains[0] = new Domain("Math", 9.00);
            testDomains[1] = new Domain("Physics", 6.20);
            testDomains[2] = new Domain("Chemistry", 7.40);
            Student testStudent = new Student("Andrei", testDomains);
            Assert.True(testStudent.MatchName("Andrei"));
            Assert.True(testStudent.MatchDomain(1, "Math", 9.00)
                && testStudent.MatchDomain(2, "Physics", 6.20)
                && testStudent.MatchDomain(3, "Chemistry", 7.40));
        }

        [Fact]

        public void CheckINewfGradeIsAddedToStudent()
        {
            Domain[] testDomains = new Domain[3];
            testDomains[0] = new Domain("Math", 9.00);
            Student testStudent = new Student("Andrei", testDomains);
            testStudent.AddNewGrade("Math", 8.30);
            Assert.True(testStudent.MatchDomain(1, "Math", 8.30));
        }
    }
}
