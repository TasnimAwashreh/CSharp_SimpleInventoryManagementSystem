using SimpleInventoryManagementSystem.App.Enums;
using SimpleInventoryManagementSystem.App;
using Microsoft.Extensions.DependencyInjection;
using SimpleInventoryManagementSystem.App.Configurations;

class Program
{
    public static void ProcessInput(ManagementSystem managementSystem, string userInput)
    {
        var productInfo = userInput.Split(' ');
        var userCommand = productInfo[0];
        var command = userCommand.ParseCommand();
        managementSystem.ExecuteCommand(productInfo, command);
    }

    public static void StartLoop(ManagementSystem system)
    {
        while (true)
        {
            Console.WriteLine(Constants.Seperator);
            var input = Console.ReadLine();
            if (input == null) Console.WriteLine(Constants.EmptyInput);
            else ProcessInput(system, input);
        }
    }

    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddServices();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        RunApp(serviceProvider);
    }

    public static void RunApp(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var system = scope.ServiceProvider.GetRequiredService<ManagementSystem>();
        Console.WriteLine(Constants.Introduction);
        StartLoop(system);
    }
}
