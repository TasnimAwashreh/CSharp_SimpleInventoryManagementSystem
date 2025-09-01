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
            var products = _inventoryRepository.GetProducts();
            if (products.Count == 0)
                return 0;
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

        public void Delete(string[] productInfo)
        {
            if (productInfo.Length != 2)
            {
                Console.WriteLine($"Please use the format: 'delete [product_name]' to delete a product");
                return;
            }

            try
            {
                string productName = productInfo[1];

                Product? existingProduct = _inventoryRepository.FindProduct(productName);
                if (existingProduct == null)
                    Console.WriteLine($"The product with the name {productName} does not exist");
                else
                {
                    try
                    {
                        _inventoryRepository.DeleteProduct(existingProduct);
                        Console.WriteLine("Product has been successfully deleted");
                    }
                    catch
                    {
                        Console.WriteLine("\n There has been a problem deleting the product. Please try again later");
                    }
                }
            }
            catch { Console.WriteLine("\n Please enter information in the correct format"); }
        }
        public void Search(string[] productInfo)
        {
            if (productInfo.Length != 2)
            {
                Console.WriteLine($"Please use the format: 'search [product_name]' to view that product's details");
                return;
            }

            string productName = productInfo[1];
            Product? existingProduct = _inventoryRepository.FindProduct(productName);
            if (existingProduct == null) Console.WriteLine($"The product with the name {productName} does not exist");
            else Console.WriteLine($"Search Result: {existingProduct}");
        }
    }
}
