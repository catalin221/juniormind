using System;

namespace LinqApplications
{
    public class TestResults
    {
        public TestResults(string id, string familyId, int score)
        {
            Id = id;
            FamilyId = familyId;
            Score = score;
        }

        public string FamilyId { get; set; }

        public string Id { get; set; }

        public int Score { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}