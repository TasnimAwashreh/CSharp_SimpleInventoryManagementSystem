using SIMS.Enums;
using System.Text;
using SIMS.Models;

namespace SIMS.Services
{
    public class ManagementSystem
    {
        private InventoryService _inventoryService;

        public ManagementSystem(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void ExecuteCommand(string[] productInfo, Command command)
        {
            switch (command)
            {
                case Command.Insert:
                    Insert(productInfo);
                    break;
                case Command.View:
                    View(productInfo);
                    break;
                case Command.EditName:
                    Edit(productInfo, str => str, (product, newProductName) => _inventoryService.UpdateProductName(product, newProductName));
                    break;
                case Command.EditPrice:
                    Edit(productInfo, decimal.Parse, (product, newPrice) => _inventoryService.UpdateProductPrice(product, newPrice));
                    break;
                case Command.EditQuantity:
                    Edit(productInfo, int.Parse, (product, newQty) => _inventoryService.UpdateProductQty(product, newQty));
                    break;
                case Command.Delete:
                    Delete(productInfo); break;
                case Command.Search:
                    Search(productInfo); break;
                case Command.Exit:
                    Environment.Exit(0); break;
                case Command.None:
                    Console.WriteLine("\n Please enter an appropriate action");
                    break;
            }
        }

        public void Insert(string[] productInfo)
        {
            if (productInfo.Length != 4)
            {
                Console.WriteLine("Please enter the product name, price, and product quantity to insert");
                return;
            }
            try
            {
                string productName = productInfo[1];
                decimal price = decimal.Parse(productInfo[2]);
                int quantity = int.Parse(productInfo[3]);

                Product? getProduct = _inventoryService.FindProduct(productName);
                if (getProduct != null)
                {
                    Console.WriteLine($"\n The product '{productName}' already exists. ");
                    return;
                }
                Product newProduct = new Product(productName, price, quantity);
                bool isInsertSuccess = _inventoryService.InsertProduct(newProduct);
                if (isInsertSuccess) Console.WriteLine($"\n Product {productName} has been inserted successfully. Total Inventory: {_inventoryService.GetCount()} products");
                else Console.WriteLine($"\n Error: Product has not been inserted, please try again");
                
            }
            catch (FormatException) { Console.WriteLine("\n Please enter price and quantity as numbers"); }
            catch { Console.WriteLine("\n Please enter information in the correct format"); }
            
        }
        public void View(string[] productInfo)
        {
            StringBuilder strBuilder = new StringBuilder();
            List<Product> inventory = _inventoryService.GetProducts();
            if (inventory.Count <= 0)
            {
                Console.WriteLine("\n Inventory is currently empty");
                return;
            }
            strBuilder.Append("\n Inventory: \n");
            foreach (Product product in inventory)
            {
                strBuilder.Append($"- {product.ToString()} \n");
            }
            Console.WriteLine(strBuilder.ToString());
        }
        public void Edit<T>(string[] productInfo, Func<string, T> parseValue, Action<Product, T> updateProduct)
        {
            if (productInfo.Length != 3)
            {
                Console.WriteLine($"Please enter commands in the correct form");
                return;
            }
            try
            {
                string productName = productInfo[1];
                T newValue = parseValue(productInfo[2]);

                Product? existingProduct = _inventoryService.FindProduct(productName);
                if (existingProduct == null)
                {
                    Console.WriteLine($"The product with the name {productName} does not exist");
                    return;
                }
                    
                else
                {
                    try
                    {
                        updateProduct(existingProduct, newValue);
                        Console.WriteLine("Product has been successfully updated");
                    }
                    catch
                    {
                        Console.WriteLine("\n Product has not been updated. Please try again. If you are updating the name, " +
                        "please make sure the new product name does not conflict with an older product's name");
                    }
                }
                    
            }
            catch (FormatException) { Console.WriteLine("\n Please enter price and quantity as numbers"); }
            catch { Console.WriteLine("\n Please enter information in the correct format"); }
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

                Product? existingProduct = _inventoryService.FindProduct(productName);
                if (existingProduct == null)
                    Console.WriteLine($"The product with the name {productName} does not exist");
                else
                {
                    try
                    {
                        _inventoryService.DeleteProduct(existingProduct);
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
            Product? existingProduct = _inventoryService.FindProduct(productName);
            if (existingProduct == null) Console.WriteLine($"The product with the name {productName} does not exist");
            else Console.WriteLine($"Search Result: {existingProduct}");
        }
    }
}

