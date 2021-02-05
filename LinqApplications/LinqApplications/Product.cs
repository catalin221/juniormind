using System;

namespace LinqApplications
{
    public class Product
    {
        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; }

        public int Quantity { get; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Equals(Quantity);
        }

        public override int GetHashCode()
        {
            return Quantity.GetHashCode();
        }
    }
}
