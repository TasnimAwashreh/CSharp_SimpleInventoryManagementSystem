using SimpleInventoryManagementSystem.Data.Models;

namespace SimpleInventoryManagementSystem.Logic.Services
{
    public interface IInventoryService
    {
        public int GetInventoryCount();
        bool Insert(string productName, decimal price, int quantity);
        string View();
        bool UpdateName(string productName, string newProductName);
        bool UpdatePrice(string productName, decimal newPrice);
        bool UpdateQuantity(string productName, int newQty);
        public bool Delete(string productName);
        public Product? Search(string productName);
    }
}
