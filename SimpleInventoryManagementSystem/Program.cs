using SIMS.Services;
using SIMS.Enums;

class Program
{
    public static void ProcessInput(ManagementSystem managementSystem, string userInput)
    {
        string[] productInfo = userInput.Split(' ');
        string userCommand = productInfo[0];
        Command command = UserCommands.ParseCommand(userCommand);
        managementSystem.ExecuteCommand(productInfo, command);

    }
    public static void StartLoop(ManagementSystem system)
    {
        while (true)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            var input = Console.ReadLine();
            if (input == null)
                Console.WriteLine("Empty input: Please try again");
            else
            {
                ProcessInput(system, input);
            }
        }
    }

    public static string Introduction()
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

                - To delete product:
                  'delete [product_name]'

                - To search for a product:
                  'search [product_name]'

                - To exit: simply type 'exit'
            """;
        return controls;
    }
    static void Main(string[] args)
    {
        InventoryService productService = new InventoryService([]);
        ManagementSystem system = new ManagementSystem(productService);
        Console.WriteLine(Introduction());
        StartLoop(system);
    }
}
