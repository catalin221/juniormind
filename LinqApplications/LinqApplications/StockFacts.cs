using Xunit;
using System.Collections.Generic;

namespace LinqApplications
{
    public class StockFacts
    {
        [Fact]
        public void AddProductAddsOneProduct()
        {
            var snickers = new Product("snickers", 15);
            var croissant = new Product("croissant", 10);
            var bagels = new Product("bagels", 20);
            var products = new Stock(new List<Product> { snickers, croissant });
            products.AddProducts(bagels);
            Assert.Equal(20, products.GetQuantity(bagels));
        }

        [Fact]
        public void AddQuantityToExistingProduct()
        {
            var snickers = new Product("snickers", 15);
            var croissant = new Product("croissant", 10);
            var products = new Stock(new List<Product> { snickers, croissant });
            products.AddProducts("croissant", 5);
            Assert.Equal(15, products.GetQuantity(croissant));
        }

        [Fact]
        public void BuyShouldBuyOneProduct()
        {
            var snickers = new Product("snickers", 15);
            var products = new Stock(new List<Product> { snickers });
            products.Buy("snickers", 1);
            Assert.Equal(14, products.GetQuantity(snickers));
        }

        [Fact]
        public void BuyShouldBuyMultipleProduct()
        {
            var snickers = new Product("snickers", 15);
            var products = new Stock(new List<Product> { snickers });
            products.Buy("snickers", 5);
            Assert.Equal(10, products.GetQuantity(snickers));
        }

        [Fact]
        public void CallbackShouldBeCalledAfterBuy()
        {
            var products = new Stock(new List<Product> { new Product("snickers", 15) });
            int testQuantity = 0;
            Product testProduct = null;
            void TestCallback(Product product, int quantity)
            {
                testProduct = product;
                testQuantity = quantity;
            }

            products.AddCalback(TestCallback);
            products.Buy("snickers", 6);
            Assert.Equal(9, testQuantity);
        }
    }
}
