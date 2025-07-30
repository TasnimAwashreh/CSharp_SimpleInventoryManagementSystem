using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public class Product
    {
        private string productName;
        private decimal price;
        private int quantity;

        public Product(string productName, decimal price, int quantity) 
        {
            this.productName = productName;
            this.price = price;
            this.quantity = quantity;
        }

    }
}
