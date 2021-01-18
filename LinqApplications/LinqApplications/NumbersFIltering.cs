using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public class NumbersFiltering
    {
        public static IEnumerable<IEnumerable<int>> GetSubsetsOfSpecificSum(IEnumerable<int> source, int maxSum)
        {
            return source.SelectMany((x, index) => source.Skip(index)
            .Select((number, secondIndex) => source
            .Skip(secondIndex).Take(source.Count() - secondIndex - index))
             .Where(x => x.Sum() <= maxSum));
        }
    }
}
