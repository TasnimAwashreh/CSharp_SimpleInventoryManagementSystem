
using SIMS.Models;

namespace SIMS.Services
{
    public class ProductService
    {
        private List<Product> _products;

        public ProductService(List<Product> products)
        {
            this._products = products;
        }

        public int GetCount() 
        { 
            return _products.Count;
        }

        public List<Product> GetProducts()
        {
            return this._products;
        }

        public Product? FindProduct(string name)
        {
            foreach (var product in _products)
            {
                if (product.GetName() == name)
                {
                    return product;
                }
            }
            return null;
        }

        public bool InsertProduct(Product product)
        {
            int productListSize = _products.Count;
            _products.Add(product);
            return _products.Count > productListSize;
        }

        public bool UpdateProductName(Product product, string newName)
        {
            if (FindProduct(newName) != null)
                return false;
            product.UpdateName(newName);
            return true;
            
        }

        public bool UpdateProductPrice(Product product, decimal newPrice)
        {
            product.UpdatePrice(newPrice);
            return true;
        }

        public bool UpdateProductQty(Product product, int newQty)
        {
            product.UpdateQty(newQty);
            return true;
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                _products.Remove(product);
                return true;
            }
            catch {return false; }
            
        }

    }
}
