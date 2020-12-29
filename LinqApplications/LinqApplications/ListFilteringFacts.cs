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
        public void AllFeatruesProductsFindsProductsWithAllFeatures()
        {
            Feature firstFeature = new Feature(2);
            Feature secondFeature = new Feature(3);
            FeatureProduct apples = new FeatureProduct("appels", new List<Feature> { firstFeature, secondFeature });
            FeatureProduct pears = new FeatureProduct("pears", new List<Feature> { secondFeature });
            var productList = new List<FeatureProduct> { apples, pears };
            var filteringCriteria = new List<Feature> { firstFeature, secondFeature };
            var filtered = ListFiltering.AllFeaturesProducts(productList, filteringCriteria);
            Assert.Equal(new List<FeatureProduct> { apples }, filtered);
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
