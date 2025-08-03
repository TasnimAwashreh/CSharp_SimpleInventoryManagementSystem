using SIMS.Enums;
using SIMS.Models;
using SIMS.Services;

class Program
{
    public static void processInput(ManagementSystem system, string userInput)
    {
        string[] productInfo = userInput.Split(' ');
        string userCommand = productInfo[0];
        Command command = UserCommands.GetCommand(userCommand);
        system.executeCommand(productInfo, command);

    }
    public static void startLoop(ManagementSystem system)
    {
        while (true)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            var input = Console.ReadLine();
            if (input == null)
                Console.WriteLine("Empty input: Please try again");
            else
            {
                processInput(system, input);
            }
        }
    }

    public static string introduction()
    {
        string controls =
            $"""
            ============================================================================================
            **                                                                                        **
            **                           Welcome to the Inventory Management System                   **
            **                                                                                        **
            ============================================================================================
            How to Use:
                - To add a product to the inventory: 
                  'insert [product_name] [price] [quantity]'
                  Example: insert potato 6.50 7

                - To view the current inventory, simply type in 'view'

                - To update the product's name:
                  'edit_name [product_name] [new product name]'

                - To update the product's quantity:
                  'edit_quantity [current_quantity] [new_quantity]'

                - To update the product's price:
                  'edit_price [old_price] [new_price]'
            """;
        return controls;
    }
    static void Main(string[] args)
    {
        ProductService productService = new ProductService([]);
        ManagementSystem system = new ManagementSystem(productService);
        Console.WriteLine(introduction());
        startLoop(system);
    }
}
