using SIMS.Enums;
using System.Text;
using SIMS.Services;
namespace SIMS.Models
{
    public class ManagementSystem
    {
        private ProductService _productService;

        public ManagementSystem(ProductService productService)
        {
            _productService = productService;
        }

        public void executeCommand(string[] productInfo, Command command)
        {
            switch (command)
            {
                case Command.insert:
                    if (productInfo.Length == 4)
                    {
                        try
                        {
                            string productName = productInfo[1];
                            decimal price = decimal.Parse(productInfo[2]);
                            int quantity = int.Parse(productInfo[3]);

                            Product newProduct = new Product(productName, price, quantity);
                            bool isInsertSuccess = _productService.InsertProduct(newProduct);
                            if (isInsertSuccess) Console.WriteLine($"\n Product has been inserted successfully. Total Inventory: {_productService.GetCount()} products");

                            else Console.WriteLine($"\n Error: Product has not been inserted, please try again");
                        }
                        catch (FormatException) { Console.WriteLine("\n Please enter price and quantity as numbers"); }
                        catch (Exception ex) { Console.WriteLine("\n Please enter information in the correct format"); }
                    }
                    else Console.WriteLine("Please enter the product name, price, and product quantity to insert");
                    break;
                case Command.view:
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
                    break;
                case Command.none:
                    Console.WriteLine("\n Please enter an appropriate action");
                    break;
            }
        }

    }
}
