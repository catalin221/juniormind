using Xunit;

namespace StudentCatalogue
{
    public class StudentsCatalogueTests
    {
        [Fact]

        public void CheckForWorkingConstructor()
        {
            Student[] testStudents = new Student[3];
            testStudents[0] = new Student("Andrei", 9.00);
            testStudents[1] = new Student("Paul", 9.30);
            testStudents[2] = new Student("Adi", 9.90);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Assert.True(testStudents[0].GetName() == "Andrei" && (testStudents[0].GetGrade() - 9.10) < 0.00001);
            Assert.True(testStudents[1].GetName() == "Paul" && (testStudents[1].GetGrade() - 9.30) < 0.00001);
            Assert.True(testStudents[2].GetName() == "Adi" && (testStudents[2].GetGrade() - 9.90) < 0.00001);
        }

        [Fact]

        public void CheckIfNewStudentIsAddedToCatalogue()
        {
            Student[] testStudents = new Student[4];
            testStudents[0] = new Student("Andrei", 9.00);
            testStudents[1] = new Student("Paul", 9.30);
            testStudents[2] = new Student("Adi", 9.90);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            testCatalogue.AddNewStudent(new Student("George", 8.40));
            Assert.True(testCatalogue.GetStudents()[3].GetName() == "George" && (testCatalogue.GetStudents()[3].GetGrade() - 8.40) < 0.0001);
        }

        [Fact]

        public void CheckForReturnedStudentOnPosition()
        {
            Student[] testStudents = new Student[3];
            testStudents[0] = new Student("Paul", 9.30);
            testStudents[1] = new Student("Andrei", 9.00);
            testStudents[2] = new Student("Adi", 9.90);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Assert.True(testCatalogue.GetStudentByPosition(3) == "Adi");
        }

        [Fact]

        public void CheckForReturnedStudentPositionByName()
        {
            Student[] testStudents = new Student[3];
            testStudents[2] = new Student("Andrei", 9.00);
            testStudents[1] = new Student("Paul", 9.30);
            testStudents[0] = new Student("Adi", 9.90);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Assert.Equal(0, testCatalogue.GetStudentPositionByName("Andrei"));
        }

        [Fact]

        public void CheckThatStudentIsNotInCatalogueByName()
        {
            Student[] testStudents = new Student[3];
            testStudents[2] = new Student("Andrei", 9.00);
            testStudents[1] = new Student("Paul", 9.30);
            testStudents[0] = new Student("Adi", 9.90);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Assert.Equal(-1, testCatalogue.GetStudentPositionByName("George"));
        }
    }
}
