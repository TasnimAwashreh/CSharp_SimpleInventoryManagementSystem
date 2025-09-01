using Microsoft.Extensions.DependencyInjection;
using SimpleInventoryManagementSystem.Data.Repository;
using SimpleInventoryManagementSystem.Logic.Services;

namespace SimpleInventoryManagementSystem.App.Configurations
{
    public static class Configuration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IInventoryRepository, InventoryRepository>()
                .AddScoped<IInventoryService, InventoryService>()

                .AddScoped<ManagementSystem>();
            return services;
        }
    }
}
