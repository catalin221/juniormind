using Xunit;
using System.Collections.Generic;

namespace LinqApplications
{
    public class ListFilteringFacts
    {
        [Fact]
        public void OneFeatureProductsFindsProductsWithContainingFeature()
        {
            var snickersFeatures = new List<Feature> { new Feature(251), new Feature(247) };
            var snickers = new FeatureProduct("Snickers", snickersFeatures);
            var bountyFeatures = new List<Feature> { new Feature(240), new Feature(247) };
            var bounty = new FeatureProduct("Bounty", bountyFeatures);
            List<FeatureProduct> testList = new List<FeatureProduct> { snickers, bounty };
            Assert.Equal(new List<FeatureProduct> { snickers }, ListFiltering.OneFeatureProducts(testList, new List<Feature> { new Feature(251) }));
        }

        [Fact]
        public void AllFeaturesProductsFindsProductsWithAllContainingFeatures()
        {
            var snickersFeatures = new List<Feature> { new Feature(251), new Feature(247) };
            var snickers = new FeatureProduct("Snickers", snickersFeatures);
            var bountyFeatures = new List<Feature> { new Feature(240), new Feature(247) };
            var bounty = new FeatureProduct("Bounty", bountyFeatures);
            List<FeatureProduct> testList = new List<FeatureProduct> { snickers, bounty };
            Assert.Equal(new List<FeatureProduct> { snickers }, ListFiltering.AllFeaturesProducts(testList, new List<Feature> { new Feature(251), new Feature(247) }));
        }

        [Fact]
        public void AllFeaturesProductsDoesNotFindProductsWithAllContainingFeatures()
        {
            var snickersFeatures = new List<Feature> { new Feature(251), new Feature(247) };
            var snickers = new FeatureProduct("Snickers", snickersFeatures);
            var bountyFeatures = new List<Feature> { new Feature(240), new Feature(247) };
            var bounty = new FeatureProduct("Bounty", bountyFeatures);
            List<FeatureProduct> testList = new List<FeatureProduct> { snickers, bounty };
            Assert.Empty(ListFiltering.AllFeaturesProducts(testList, new List<Feature> { new Feature(251), new Feature(240) }));
        }

        [Fact]
        public void NoFeaturesProductsFindsProductsWithNoContainingFeatures()
        {
            var snickersFeatures = new List<Feature> { new Feature(251), new Feature(241) };
            var snickers = new FeatureProduct("Snickers", snickersFeatures);
            var bountyFeatures = new List<Feature> { new Feature(240), new Feature(247) };
            var bounty = new FeatureProduct("Bounty", bountyFeatures);
            List<FeatureProduct> testList = new List<FeatureProduct> { snickers, bounty };
            Assert.Equal(new List<FeatureProduct> { snickers }, ListFiltering.NoFeatureProducts(testList, new List<Feature> { new Feature(240), new Feature(245) }));
        }
    }
}
