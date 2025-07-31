

namespace SIMS.Models
{
    public class Product
    {
        private string productName;
        private decimal price;
        private int quantity; 

        public Product(string productName, decimal price, int quantity) 
        {
            this.productName = productName;
            this.price = price;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return $"{productName}: Price: {price}; Qty: {quantity}";
        }

    }
}
