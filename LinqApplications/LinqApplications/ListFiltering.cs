using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public class ListFiltering
    {
        public static List<FeatureProduct> OneFeatureProducts(List<FeatureProduct> source, List<Feature> specified)
        {
            return source.Where(element => element.Features.Intersect(specified, new IdComparer()).Any()).ToList();
        }

        public static List<FeatureProduct> AllFeaturesProducts(List<FeatureProduct> source, List<Feature> specified)
        {
            return source.Where(product => specified.All(feature => product.Features.Contains(feature))).ToList();
        }

        public static List<FeatureProduct> NoFeatureProducts(List<FeatureProduct> source, List<Feature> specified)
        {
            return source.Where(element => !element.Features.Intersect(specified, new IdComparer()).Any()).ToList();
        }
    }
}
