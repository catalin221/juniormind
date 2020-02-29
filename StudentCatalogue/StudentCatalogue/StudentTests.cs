using Xunit;

namespace StudentCatalogue
{
    public class StudensTests
    {
        [Fact]
        public void CheckForWorkingConstructor()
        {
            Student testStudent = new Student(9.00);
            Assert.True(testStudent.Grade - 0.0001 <= 9.00);
        }

        [Fact]

        public void CheckINewfGradeIsAddedToStudent()
        {
            Student testStudent = new Student(9.00);
            testStudent.AddNewGrade(9.10);
            Assert.True(testStudent.Grade - 0.0001 <= 9.10);
        }
    }
}
