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
    }
}
