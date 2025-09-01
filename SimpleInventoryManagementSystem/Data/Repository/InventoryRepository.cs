using SimpleInventoryManagementSystem.Data.Models;

namespace SimpleInventoryManagementSystem.Data.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Product> _products;

        public InventoryRepository()
        {
            _products = new();
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product? FindProduct(string name)
        {
            foreach (var product in _products)
            {
                if (product.ProductName == name)
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

        public void UpdateProductName(Product product, string newName)
        {
            product.ProductName = newName;
        }

        public void UpdateProductPrice(Product product, decimal newPrice)
        {
            product.Price = newPrice;
        }

        public void UpdateProductQty(Product product, int newQty)
        {
            product.Quantity = newQty;
        }

        public void DeleteProduct(Product product)
        {
            _products.Remove(product);
        }
    }
}
