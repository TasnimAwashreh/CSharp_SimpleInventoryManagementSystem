using SimpleInventoryManagementSystem.Data.Models;

namespace SimpleInventoryManagementSystem.Data.Repository
{
    public interface IInventoryRepository
    {
        public List<Product> GetProducts();
        public Product? FindProduct(string name);
        public bool InsertProduct(Product product);
        public void UpdateProductName(Product product, string newName);
        public void UpdateProductPrice(Product product, decimal newPrice);
        public void UpdateProductQty(Product product, int newQty);
        public void DeleteProduct(Product product);
    }
}
