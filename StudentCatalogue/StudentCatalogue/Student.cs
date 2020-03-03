namespace StudentCatalogue
{
    public class Student
    {
        private readonly string name;
        private double grade;

        public Student(string name, double grade)
        {
            this.grade = grade;
            this.name = name;
        }

        public double GetGrade()
        {
            return this.grade;
        }

        public string GetName()
        {
            return this.name;
        }

        public void AddNewGrade(double newGrade)
        {
            this.grade = newGrade;
        }
    }
}
