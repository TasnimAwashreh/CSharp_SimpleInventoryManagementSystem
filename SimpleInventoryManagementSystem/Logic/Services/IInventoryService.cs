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
        void Delete(string[] productInfo);
        void Search(string[] productInfo);
    }
}
