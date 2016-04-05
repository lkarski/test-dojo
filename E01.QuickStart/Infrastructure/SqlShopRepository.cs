using E01.QuickStart.Core;
using E01.QuickStart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace E01.QuickStart.Infrastructure
{
    public class SqlShopRepository : IShopRepository
    {
        public Order GetOrderFor(Customer customer)
        {
            // connect to database
            Thread.Sleep(1000);

            if (customer.Name == "John")
            {
                return new Order()
                {
                    Number = "123A",
                    IsReady = true
                };
            }
            else
            {
                return null;
            }
        }

        public Package GetPackageFor(Order order)
        {
            // query database
            Thread.Sleep(1000);

            if (order.Number == "123A")
            {
                return new Package();
            }
            else
            {
                return null;
            }
        }
    }
}
