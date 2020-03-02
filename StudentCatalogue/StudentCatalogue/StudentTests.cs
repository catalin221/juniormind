using Xunit;

namespace StudentCatalogue
{
    public class StudentTests
    {
        [Fact]
        public void CheckForWorkingConstructor()
        {
            Student testStudent = new Student("Andrei", 9.00);
            Assert.True(testStudent.Name == "Andrei");
            Assert.True(testStudent.Grade - 0.0001 <= 9.00);
        }

        [Fact]

        public void CheckINewfGradeIsAddedToStudent()
        {
            Student testStudent = new Student("Andrei", 9.00);
            testStudent.AddNewGrade(9.10);
            Assert.True(testStudent.Grade - 0.0001 <= 9.10);
        }
    }
}
