using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public class Stock
    {
        private readonly List<Product> stock;
        private Action<Product, int> callback;

        public Stock() : this(new List<Product>())
        {
        }

        public Stock(List<Product> products)
        {
            stock = products;
        }

        public void AddCalback(Action<Product, int> action)
        {
            callback = action;
        }

        public void AddProducts(params Product[] toAdd)
        {
            foreach (var product in toAdd)
            {
                stock.Add(product);
            }
        }

        public void AddProducts(string productName, int quantity)
        {
            Product toFind = stock.Single(element => element.Name == productName);
            Product toReplace = new Product(toFind.Name, toFind.Quantity + quantity);
            stock.Remove(toFind);
            stock.Add(toReplace);
        }

        public int GetQuantity(Product product)
        {
            return stock.Single(x => x.Name == product.Name).Quantity;
        }

        public void Buy(string productName, int quantity)
        {
            Product toFind = stock.Single(element => element.Name == productName);
            Product toReplace = new Product(toFind.Name, toFind.Quantity - quantity);
            stock.Remove(toFind);
            stock.Add(toReplace);
            CallbackAction(toReplace, toFind.Quantity);
        }

        private bool CheckQuantity(int currentQuantity, int previousQuantity, int limit)
        {
            return previousQuantity >= limit && currentQuantity < limit;
        }

        private void CallbackAction(Product product, int previousQuantity)
        {
            if (callback == null || !CheckCallback(product, previousQuantity))
            {
                return;
            }

            callback(product, product.Quantity);
        }

        private bool CheckCallback(Product product, int previousQuantity)
        {
            int currentQuantity = product.Quantity;

            return CheckQuantity(currentQuantity, previousQuantity, 10)
                || CheckQuantity(currentQuantity, previousQuantity, 5)
                || CheckQuantity(currentQuantity, previousQuantity, 2);
        }
    }
}
