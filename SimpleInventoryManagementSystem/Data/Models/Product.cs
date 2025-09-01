namespace SimpleInventoryManagementSystem.Data.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string productName, decimal price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{ProductName}: Price: {Price}; Qty: {Quantity}";
        }
    }
}
