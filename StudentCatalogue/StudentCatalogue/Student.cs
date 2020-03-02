namespace StudentCatalogue
{
    public class Student
    {
        public double Grade;
        public string Name;

        public Student(string name, double grade)
        {
            this.Grade = grade;
            this.Name = name;
        }

        public void AddNewGrade(double newGrade)
        {
            this.Grade = newGrade;
        }
    }
}
