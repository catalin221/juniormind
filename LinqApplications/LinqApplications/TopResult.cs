using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public static class TopResult
    {
        public static IEnumerable<TestResults> GetMaxPerFamily(IEnumerable<TestResults> list)
        {
            return list.GroupBy(x => x.FamilyId)
                        .Select(x =>
                    {
                        var first = x.First();
                        return x.Aggregate(first, (maximumScore, currentScore) =>
                            currentScore.Score > maximumScore.Score
                                ? currentScore
                                : maximumScore);
                    });
        }
    }
}
