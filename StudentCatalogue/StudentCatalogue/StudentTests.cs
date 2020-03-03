using Xunit;

namespace StudentCatalogue
{
    public class StudentTests
    {
        [Fact]
        public void CheckForWorkingConstructor()
        {
            Student testStudent = new Student("Andrei", 9.00);
            Assert.True(testStudent.GetName() == "Andrei");
            Assert.True(testStudent.GetGrade() - 9.00 < 0.0001);
        }

        [Fact]

        public void CheckINewfGradeIsAddedToStudent()
        {
            Student testStudent = new Student("Andrei", 9.00);
            testStudent.AddNewGrade(9.10);
            Assert.True(testStudent.GetGrade() - 9.10 < 0.001);
        }
    }
}
