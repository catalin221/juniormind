using System;

namespace StudentCatalogue
{
    public class Student
    {
        private readonly string name;
        private readonly Domain[] domains;

        public Student(string name, Domain[] domains)
        {
            this.domains = domains;
            this.name = name;
        }

        public bool MatchName(string name)
        {
            return this.name == name;
        }

        public bool MatchDomain(int domainPosition, string domain, double grade)
        {
            return domains[domainPosition - 1].MatchDomain(domain) && domains[domainPosition - 1].MatchGrade(grade);
        }

        public double GetArithmeticAverage()
        {
            int count = 0;
            double result = 0;
            for (int i = 0; i < this.domains.Length; i++)
            {
                count++;
                result += domains[i].GetGrade();
            }

            return result / count;
        }

        public string GetName()
        {
            return this.name;
        }

        public void AddNewGrade(string domain, double newGrade)
        {
            for (int i = 0; i < domains.Length; i++)
            {
                if (domains[i].MatchDomain(domain))
                {
                    domains[i].AddNewGrade(newGrade);
                    break;
                }
            }
        }
    }
}
