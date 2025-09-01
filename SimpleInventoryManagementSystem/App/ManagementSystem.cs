using SimpleInventoryManagementSystem.App.Enums;
using SimpleInventoryManagementSystem.Logic.Services;

namespace SimpleInventoryManagementSystem.App
{
    public class ManagementSystem
    {
        private IInventoryService _inventoryService;

        public ManagementSystem(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void ExecuteCommand(string[] productInfo, Command command)
        {
            switch (command)
            {
                case Command.Insert:
                    if (productInfo.Length != 4)
                    {
                        Console.WriteLine(Constants.InsertProduct);
                        return;
                    }

                    try
                    {
                        string productName = productInfo[1];
                        decimal price = decimal.Parse(productInfo[2]);
                        int quantity = int.Parse(productInfo[3]);

                        bool isSuccess = _inventoryService.Insert(productName, price, quantity);
                        if (!isSuccess) Console.WriteLine(Constants.ProductExists);
                        else Console.WriteLine(Constants.ProductInserted);
                    }
                    catch { Console.WriteLine(Constants.IncorrectFormat); }
                    break;
                case Command.View:
                    string result = _inventoryService.View();
                    Console.WriteLine(result);
                    break;
                case Command.EditName:
                    if (productInfo.Length != 3)
                    {
                        Console.WriteLine(Constants.UpdateName);
                        return;
                    }

                    try
                    {
                        string productName = productInfo[1];
                        string newProductName = productInfo[2];
                        bool isSuccesful = _inventoryService.UpdateName(productName, newProductName);
                        if (!isSuccesful) Console.WriteLine(Constants.ProductDoesNotExist);
                        else Console.WriteLine($"{Constants.SuccessfulProductUpdate} to {newProductName}");
                    }
                    catch (FormatException) { Console.WriteLine(Constants.UpdateNameFormatIncorrect); }
                    catch { Console.WriteLine(Constants.IncorrectInformation); }

                    break;
                case Command.EditPrice:
                    if (productInfo.Length != 3)
                    {
                        Console.WriteLine(Constants.UpdatePrice);
                        return;
                    }

                    try
                    {
                        string productName = productInfo[1];
                        decimal newPrice = decimal.Parse(productInfo[2]);
                        bool isSuccesful = _inventoryService.UpdatePrice(productName, newPrice);
                        if (!isSuccesful) Console.WriteLine(Constants.ProductDoesNotExist);
                        else Console.WriteLine(Constants.SuccessfulProductUpdate);
                    }
                    catch (FormatException) { Console.WriteLine(Constants.UpdatePriceFormatIncorrect); }
                    catch { Console.WriteLine(Constants.IncorrectInformation); }

                    break;
                case Command.EditQuantity:
                    if (productInfo.Length != 3)
                    {
                        Console.WriteLine(Constants.UpdateQty);
                        return;
                    }

                    try
                    {
                        string productName = productInfo[1];
                        int newQty = int.Parse(productInfo[2]);
                        bool isSuccesful = _inventoryService.UpdateQuantity(productName, newQty);
                        if (!isSuccesful) Console.WriteLine(Constants.ProductDoesNotExist);
                        else Console.WriteLine(Constants.SuccessfulProductUpdate);
                    }
                    catch (FormatException) { Console.WriteLine(Constants.UpdateQtyFormatIncorrect); }
                    catch { Console.WriteLine(Constants.IncorrectInformation); }

                    break;
                case Command.Delete:
                    _inventoryService.Delete(productInfo); break;
                case Command.Search:
                    _inventoryService.Search(productInfo); break;
                case Command.Exit:
                    Environment.Exit(0); break;
                case Command.None:
                    Console.WriteLine(Constants.AppropriateActionError);
                    break;
            }
        }
    }
}

