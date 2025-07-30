using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Models;

namespace SIMS.Services
{
    public class ProductService
    {
        private List<Product> inventory;

        public ProductService(List<Product> inventory)
        {
            this.inventory = inventory;
        }

        public int GetCount() 
        { 
            return inventory.Count;
        }

        public bool InsertProduct(Product product)
        {
            int inventorySize = inventory.Count;
            inventory.Add(product);
            return inventory.Count > inventorySize;
        }

    }
}
