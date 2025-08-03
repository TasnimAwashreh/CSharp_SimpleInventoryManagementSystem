

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

        public string GetName() {return productName;}
        public decimal GetPrice() {return price;}
        public int GetQty() {return quantity;}

        public void updateName(string newName)
        {
            this.productName = newName;
        }

        public void updatePrice(decimal newPrice)
        {
            this.price = newPrice;
        }

        public void updateQty(int newQty)
        {
            this.quantity = newQty;
        }

        public override string ToString()
        {
            return $"{productName}: Price: {price}; Qty: {quantity}";
        }

    }
}
