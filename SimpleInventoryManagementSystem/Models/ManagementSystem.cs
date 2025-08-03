using SIMS.Enums;
using System.Text;
using SIMS.Services;
using System.Diagnostics;
namespace SIMS.Models
{
    public class ManagementSystem
    {
        private InventoryService _productService;

        public ManagementSystem(InventoryService productService)
        {
            _productService = productService;
        }

        public void executeCommand(string[] productInfo, Command command)
        {
            switch (command)
            {
                case Command.insert:
                    insert(productInfo);
                    break;
                case Command.view:
                    view(productInfo);
                    break;
                case Command.edit_name:

                    edit<string>(productInfo, "", str => str , (product, newProductName) => _productService.UpdateProductName(product, newProductName));
                    break;
                case Command.edit_price:
                    edit<decimal>(productInfo, "", decimal.Parse, (product, newPrice) => _productService.UpdateProductPrice(product, newPrice));
                    break;
                case Command.edit_quantity:
                    edit<int>(productInfo, "", int.Parse, (product, newQty) => _productService.UpdateProductQty(product, newQty));
                    break;
                case Command.delete: 
                    delete(productInfo); break;
                case Command.search:
                    search(productInfo); break;
                case Command.exit:
                    Environment.Exit(0); break;
                case Command.none:
                    Console.WriteLine("\n Please enter an appropriate action");
                    break;
            }
        }

        public void insert(string[] productInfo)
        {
            if (productInfo.Length == 4)
            {
                try
                {
                    string productName = productInfo[1];
                    decimal price = decimal.Parse(productInfo[2]);
                    int quantity = int.Parse(productInfo[3]);

                    Product? getProduct = _productService.FindProduct(productName);
                    if (getProduct == null)
                    {
                        Product newProduct = new Product(productName, price, quantity);
                        bool isInsertSuccess = _productService.InsertProduct(newProduct);
                        if (isInsertSuccess) Console.WriteLine($"\n Product {productName} has been inserted successfully. Total Inventory: {_productService.GetCount()} products");
                        else Console.WriteLine($"\n Error: Product has not been inserted, please try again");
                    }
                    else Console.WriteLine($"\n The product '{productName}' already exists. ");
                }
                catch (FormatException) { Console.WriteLine("\n Please enter price and quantity as numbers"); }
                catch { Console.WriteLine("\n Please enter information in the correct format"); }
            }
            else Console.WriteLine("Please enter the product name, price, and product quantity to insert");

        }
        public void view(string[] productInfo)
        {
            StringBuilder strBuilder = new StringBuilder();
            List<Product> inventory = _productService.GetInventory();
            if (inventory.Count > 0)
            {
                strBuilder.Append("\n Inventory: \n");
                foreach (Product product in inventory)
                {
                    strBuilder.Append($"- {product.ToString()} \n");
                }
                Console.WriteLine(strBuilder.ToString());
            }
            else Console.WriteLine("\n Inventory is currently empty");
        }
        public void edit<T>(string[] productInfo, string editSuccessStr, Func<string,T> parseValue, Func<Product,T,bool> updateProduct)
        {
            if (productInfo.Length == 3)
            {
                try
                {
                    string productName = productInfo[1];
                    T newValue = parseValue(productInfo[2]);

                    Product? existingProduct = _productService.FindProduct(productName); 
                    if (existingProduct != null )
                    {
                        bool success = updateProduct(existingProduct, newValue);
                        if (success) Console.WriteLine("Product has been successfully updated");
                        else Console.WriteLine("\n Product has not been updated. Please try again. If you are updating the name, " +
                            "please make sure the new product name does not conflict with an older product's name");
                    }
                    else Console.WriteLine($"The product with the name {productName} does not exist");
                }
                catch (FormatException) {Console.WriteLine("\n Please enter price and quantity as numbers"); }
                catch { Console.WriteLine("\n Please enter information in the correct format"); }
            }
            else Console.WriteLine($"Please enter commands in the correct form");
        }
        public void delete(string[] productInfo)
        {
            if (productInfo.Length == 2)
            {
                try
                {
                    string productName = productInfo[1];

                    Product? existingProduct = _productService.FindProduct(productName);
                    if (existingProduct != null)
                    {
                        bool isSuccess = _productService.DeleteProduct(existingProduct);
                        if (isSuccess) Console.WriteLine("Product has been successfully deleted");
                        else Console.WriteLine("\n There has been a problem deleting the product. Please try again later");
                    }
                    else Console.WriteLine($"The product with the name {productName} does not exist");
                }
                catch { Console.WriteLine("\n Please enter information in the correct format"); }
            }
            else Console.WriteLine($"Please use the format: 'delete [product_name]' to delete a product");
        }
        public void search(string[] productInfo)
        { 
            if (productInfo.Length == 2)
            {
                string productName = productInfo[1];
                Product? existingProduct = _productService.FindProduct(productName);
                if (existingProduct != null)
                {
                    Console.WriteLine($"Search Result: {existingProduct.ToString()}");
                }
                else Console.WriteLine($"The product with the name {productName} does not exist");

            }
            else Console.WriteLine($"Please use the format: 'search [product_name]' to view that product's details");
        }





    }
}

