namespace StudentCatalogue
{
    class Student
    {
        public double Grade;

        public Student(double grade)
        {
            this.Grade = grade;
        }

        public void AddNewGrade(double newGrade)
        {
            this.Grade = newGrade;
        }
    }
}
