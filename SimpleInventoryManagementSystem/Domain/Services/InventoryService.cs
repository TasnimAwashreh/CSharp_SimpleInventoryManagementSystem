using SimpleInventoryManagementSystem.Data.Models;
using SimpleInventoryManagementSystem.Data.Repository;
using System.Text;

namespace SimpleInventoryManagementSystem.Logic.Services
{
    public class InventoryService : IInventoryService
    {
        private InventoryRepository _inventoryRepository;

        public InventoryService(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public int GetInventoryCount()
        {
            return _inventoryRepository.GetProducts().Count;
        }

        public bool Insert(string productName, decimal price, int quantity)
        {
            Product? getProduct = _inventoryRepository.FindProduct(productName);
            if (getProduct != null)
                return false;
            Product newProduct = new Product(productName, price, quantity);
            _inventoryRepository.InsertProduct(newProduct);
            return true;
        }

        public string View()
        {
            StringBuilder strBuilder = new StringBuilder();
            List<Product> inventory = _inventoryRepository.GetProducts();
            if (inventory.Count <= 0)
            {
                return "\n Inventory is currently empty";
            }

            strBuilder.Append("\n Inventory: \n");
            foreach (Product product in inventory)
            {
                strBuilder.Append($"- {product.ToString()} \n");
            }

            return strBuilder.ToString();
        }

        private bool Edit<T>(string productName, T newValue, Action<Product, T> updateProduct)
        {
            Product? existingProduct = _inventoryRepository.FindProduct(productName);
            if (existingProduct == null)
            {
                return false;
            }
            updateProduct(existingProduct, newValue);
            return true;
        }

        public bool UpdateName(string productName, string newProductName)
        {
            return Edit(productName, newProductName,
                (product, newProductName) => _inventoryRepository.UpdateProductName(product, newProductName));
        }

        public bool UpdatePrice(string productName, decimal newPrice)
        {
            return Edit(productName, newPrice,
                (product, newPrice) => _inventoryRepository.UpdateProductPrice(product, newPrice));
        }

        public bool UpdateQuantity(string productName, int newQty)
        {
            return Edit(productName, newQty,
                (product, newQty) => _inventoryRepository.UpdateProductQty(product, newQty));
        }

        public bool Delete(string productName)
        {
            Product? existingProduct = _inventoryRepository.FindProduct(productName);
            if (existingProduct == null)
                    return false;
            _inventoryRepository.DeleteProduct(existingProduct);
            return true;
        }

        public Product? Search(string productName)
        {
            return _inventoryRepository.FindProduct(productName);
        }
    }
}
