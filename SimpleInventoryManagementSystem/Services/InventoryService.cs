using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Models;

namespace SIMS.Services
{
    public class InventoryService
    {
        private List<Product> inventory;

        public InventoryService(List<Product> inventory)
        {
            this.inventory = inventory;
        }

        public int GetCount() 
        { 
            return inventory.Count;
        }

        public List<Product> GetInventory()
        {
            return this.inventory;
        }

        public Product? FindProduct(string name)
        {
            foreach (var product in inventory)
            {
                if (product.GetName() == name)
                {
                    return product;
                }
            }
            return null;
        }

        public bool InsertProduct(Product product)
        {
            int inventorySize = inventory.Count;
            inventory.Add(product);
            return inventory.Count > inventorySize;
        }

        public bool UpdateProductName(Product product, string newName)
        {
            if (FindProduct(newName) == null)
            {
                product.UpdateName(newName);
                return true;
            }
            else return false;
        }

        public bool UpdateProductPrice(Product product, decimal newPrice)
        {
            product.UpdatePrice(newPrice);
            return true;
        }

        public bool UpdateProductQty(Product product, int newQty)
        {
            product.UpdateQty(newQty);
            return true;
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                inventory.Remove(product);
                return true;
            }
            catch {return false; }
            
        }

    }
}
