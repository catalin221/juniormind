using System.Collections.Generic;

namespace LinqApplications
{
    public class FeatureProduct
    {
        public FeatureProduct(string name, ICollection<Feature> features)
        {
            Name = name;
            Features = features;
        }

        public string Name { get; set; }

        public ICollection<Feature> Features { get; }
    }
}
