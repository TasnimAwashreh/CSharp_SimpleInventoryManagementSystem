

namespace SIMS.Models
{
    public class Product
    {
        private string _productName;
        private decimal _price;
        private int _quantity; 

        public Product(string productName, decimal price, int quantity) 
        {
            this._productName = productName;
            this._price = price;
            this._quantity = quantity;
        }

        public string GetName() {return _productName; }
        public decimal GetPrice() {return _price; }
        public int GetQty() {return _quantity; }

        public void UpdateName(string newName)
        {
            this._productName = newName;
        }

        public void UpdatePrice(decimal newPrice)
        {
            this._price = newPrice;
        }

        public void UpdateQty(int newQty)
        {
            this._quantity = newQty;
        }

        public override string ToString()
        {
            return $"{_productName}: Price: {_price}; Qty: {_quantity}";
        }

    }
}
