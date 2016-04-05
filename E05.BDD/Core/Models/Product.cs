using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E05.BDD.Core.Models
{
    public class Product
    {
        public double Price { get; set; }

        public double Quantity { get; set; }

        public double MinWholesaleQuantity { get; set; }

        public string Name { get; set; }
    }
}
