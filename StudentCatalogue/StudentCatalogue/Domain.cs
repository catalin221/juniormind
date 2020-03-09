namespace StudentCatalogue
{
    public class Domain
    {
        private readonly string domain;
        private double grade;

        public Domain(string domain, double grade)
        {
            this.domain = domain;
            this.grade = grade;
        }

        public void AddNewGrade(double newGrade)
        {
            this.grade = newGrade;
        }

        public bool MatchDomain(string domain)
        {
            return domain == this.domain;
        }

        public double GetGrade()
        {
            return this.grade;
        }

        public bool MatchGrade(double grade)
        {
            return this.grade - grade < 0.0001;
        }
    }
}
