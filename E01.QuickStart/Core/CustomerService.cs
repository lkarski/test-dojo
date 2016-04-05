using E01.QuickStart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E01.QuickStart.Core
{
    public class CustomerService
    {
        internal void AddBonusPackFor(Order order)
        {
            order.Products.Add("Surprise Bonus Pack");
        }
    }
}
