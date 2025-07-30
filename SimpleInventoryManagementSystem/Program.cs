using SIMS.Enums;
using SIMS.Models;
using SIMS.Services;
using System;

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
                - To add a product to the inventory, type in 
                  insert [product_name] [price] [quantity]
                  Example: insert potato 6.50 7

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
