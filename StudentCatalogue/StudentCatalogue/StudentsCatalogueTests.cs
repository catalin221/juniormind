using Xunit;

namespace StudentCatalogue
{
    public class StudentsCatalogueTests
    {
        [Fact]

        public void CheckForWorkingConstructor()
        {
            Domain[] testDomainsFirstStudent = new Domain[3];
            Domain[] testDomainsSecondStudent = new Domain[3];
            Domain[] testDomainsThirdStudent = new Domain[3];
            testDomainsFirstStudent[0] = new Domain("Math", 9.00);
            testDomainsFirstStudent[1] = new Domain("Physics", 6.20);
            testDomainsFirstStudent[2] = new Domain("Chemistry", 7.40);
            testDomainsSecondStudent[0] = new Domain("Math", 6.00);
            testDomainsSecondStudent[1] = new Domain("Physics", 8.14);
            testDomainsSecondStudent[2] = new Domain("Chemistry", 5.50);
            testDomainsThirdStudent[0] = new Domain("Math", 10.00);
            testDomainsThirdStudent[1] = new Domain("Physics", 7.90);
            testDomainsThirdStudent[2] = new Domain("Chemistry", 7.70);
            Student[] testStudents = new Student[3];
            testStudents[0] = new Student("Andrei", testDomainsFirstStudent);
            testStudents[1] = new Student("Paul", testDomainsSecondStudent);
            testStudents[2] = new Student("Adi", testDomainsThirdStudent);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);

            Assert.True(testCatalogue.GetStudents()[0].MatchDomain(1, "Math", 9.00) && testStudents[0].MatchName("Andrei"));
            Assert.True(testCatalogue.GetStudents()[0].MatchDomain(2, "Physics", 6.20) && testStudents[0].MatchName("Andrei"));
            Assert.True(testCatalogue.GetStudents()[0].MatchDomain(3, "Chemistry", 7.40) && testStudents[0].MatchName("Andrei"));
            Assert.True(testCatalogue.GetStudents()[1].MatchDomain(1, "Math", 6.00) && testStudents[1].MatchName("Paul"));
            Assert.True(testCatalogue.GetStudents()[1].MatchDomain(2, "Physics", 8.14) && testStudents[1].MatchName("Paul"));
            Assert.True(testCatalogue.GetStudents()[1].MatchDomain(3, "Chemistry", 5.50) && testStudents[1].MatchName("Paul"));
            Assert.True(testCatalogue.GetStudents()[2].MatchDomain(1, "Math", 10.00) && testStudents[2].MatchName("Adi"));
            Assert.True(testCatalogue.GetStudents()[2].MatchDomain(2, "Physics", 7.90) && testStudents[2].MatchName("Adi"));
            Assert.True(testCatalogue.GetStudents()[2].MatchDomain(3, "Chemistry", 7.70) && testStudents[2].MatchName("Adi"));
        }

        [Fact]

        public void CheckIfNewStudentIsAddedToCatalogue()
        {
            Domain[] testDomainsFirstStudent = new Domain[2];
            Domain[] testDomainsSecondStudent = new Domain[2];
            Domain[] testDomainsThirdStudent = new Domain[2];
            testDomainsFirstStudent[0] = new Domain("Math", 9.00);
            testDomainsFirstStudent[1] = new Domain("Physics", 6.20);
            testDomainsSecondStudent[0] = new Domain("Math", 6.00);
            testDomainsSecondStudent[1] = new Domain("Physics", 8.14);
            testDomainsThirdStudent[0] = new Domain("Math", 10.00);
            testDomainsThirdStudent[1] = new Domain("Physics", 7.90);
            Student[] testStudents = new Student[4];
            testStudents[0] = new Student("Andrei", testDomainsFirstStudent);
            testStudents[1] = new Student("Paul", testDomainsSecondStudent);
            testStudents[2] = new Student("Adi", testDomainsThirdStudent);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Domain[] testDomainsFourthStudent = new Domain[2];
            testDomainsFourthStudent[0] = new Domain("Math", 5.15);
            testDomainsFourthStudent[1] = new Domain("Physics", 7.00);
            testCatalogue.AddNewStudent(new Student("George", testDomainsFourthStudent));
            Assert.True(testCatalogue.GetStudents()[3].MatchDomain(1, "Math", 5.15) && testCatalogue.GetStudents()[3].MatchName("George"));
            Assert.True(testCatalogue.GetStudents()[3].MatchDomain(2, "Physics", 7.00) && testCatalogue.GetStudents()[3].MatchName("George"));
        }

        [Fact]

        public void CheckForReturnedStudentOnPosition()
        {
            Domain[] testDomainsFirstStudent = new Domain[2];
            Domain[] testDomainsSecondStudent = new Domain[2];
            Domain[] testDomainsThirdStudent = new Domain[2];
            testDomainsFirstStudent[0] = new Domain("Math", 9.00);
            testDomainsFirstStudent[1] = new Domain("Physics", 6.20);
            testDomainsSecondStudent[0] = new Domain("Math", 6.00);
            testDomainsSecondStudent[1] = new Domain("Physics", 8.14);
            testDomainsThirdStudent[0] = new Domain("Math", 10.00);
            testDomainsThirdStudent[1] = new Domain("Physics", 7.90);
            Student[] testStudents = new Student[3];
            testStudents[0] = new Student("Paul", testDomainsFirstStudent);
            testStudents[1] = new Student("Andrei", testDomainsSecondStudent);
            testStudents[2] = new Student("Adi", testDomainsThirdStudent);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Assert.True(testCatalogue.GetStudentByPositionInRanking(3) == "Adi");
        }

        [Fact]

        public void CheckForReturnedStudentPositionByName()
        {
            Domain[] testDomainsFirstStudent = new Domain[2];
            Domain[] testDomainsSecondStudent = new Domain[2];
            Domain[] testDomainsThirdStudent = new Domain[2];
            testDomainsFirstStudent[0] = new Domain("Math", 9.00);
            testDomainsFirstStudent[1] = new Domain("Physics", 6.20);
            testDomainsSecondStudent[0] = new Domain("Math", 6.00);
            testDomainsSecondStudent[1] = new Domain("Physics", 8.14);
            testDomainsThirdStudent[0] = new Domain("Math", 10.00);
            testDomainsThirdStudent[1] = new Domain("Physics", 7.90);
            Student[] testStudents = new Student[3];
            testStudents[0] = new Student("Paul", testDomainsFirstStudent);
            testStudents[1] = new Student("Andrei", testDomainsSecondStudent);
            testStudents[2] = new Student("Adi", testDomainsThirdStudent);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Assert.Equal(0, testCatalogue.GetStudentPositionByNameInRanking("Andrei"));
        }

        [Fact]

        public void CheckThatStudentIsNotInCatalogueByName()
        {
            Domain[] testDomainsFirstStudent = new Domain[2];
            Domain[] testDomainsSecondStudent = new Domain[2];
            Domain[] testDomainsThirdStudent = new Domain[2];
            testDomainsFirstStudent[0] = new Domain("Math", 9.00);
            testDomainsFirstStudent[1] = new Domain("Physics", 6.20);
            testDomainsSecondStudent[0] = new Domain("Math", 6.00);
            testDomainsSecondStudent[1] = new Domain("Physics", 8.14);
            testDomainsThirdStudent[0] = new Domain("Math", 10.00);
            testDomainsThirdStudent[1] = new Domain("Physics", 7.90);
            Student[] testStudents = new Student[3];
            testStudents[0] = new Student("Paul", testDomainsFirstStudent);
            testStudents[1] = new Student("Andrei", testDomainsSecondStudent);
            testStudents[2] = new Student("Adi", testDomainsThirdStudent);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Assert.Equal(-1, testCatalogue.GetStudentPositionByNameInRanking("George"));
        }
    }
}
