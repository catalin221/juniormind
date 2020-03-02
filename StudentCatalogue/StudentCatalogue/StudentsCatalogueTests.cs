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
            Assert.True(testStudents[0].Name == "Andrei" && (testStudents[0].Grade - 9.10) < 0.00001);
            Assert.True(testStudents[1].Name == "Paul" && (testStudents[1].Grade - 9.30) < 0.00001);
            Assert.True(testStudents[2].Name == "Adi" && (testStudents[2].Grade - 9.90) < 0.00001);
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
            Assert.True(testCatalogue.Catalogue[3].Name == "George" && (testCatalogue.Catalogue[3].Grade - 8.40) < 0.0001);
        }

        [Fact]

        public void CheckForReturnedStudentOnPosition()
        {
            Student[] testStudents = new Student[3];
            testStudents[0] = new Student("Paul", 9.30);
            testStudents[1] = new Student("Andrei", 9.00);
            testStudents[2] = new Student("Adi", 9.90);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Assert.True(testCatalogue.GetStudentByPosition(2) == "Paul");
        }

        [Fact]

        public void CheckForReturnedStudentPositionByName()
        {
            Student[] testStudents = new Student[3];
            testStudents[2] = new Student("Andrei", 9.00);
            testStudents[1] = new Student("Paul", 9.30);
            testStudents[0] = new Student("Adi", 9.90);
            StudentsCatalogue testCatalogue = new StudentsCatalogue(testStudents);
            Assert.True(testCatalogue.GetStudentPositionByName("Andrei") == 0);
        }
    }
}
