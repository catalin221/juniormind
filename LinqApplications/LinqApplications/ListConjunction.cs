using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public class ListConjunction
    {
        public static IEnumerable<Product> ListUnion(List<Product> firstList, List<Product> secondList)
        {
            return firstList.Concat(secondList)
                .GroupBy(x => x.Name)
                    .Select(x => new Product(
                        x.Key,
                        x.Sum(y => y.Quantity)));
        }
    }
}
