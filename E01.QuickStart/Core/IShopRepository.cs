using E01.QuickStart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E01.QuickStart.Core
{
    public interface IShopRepository
    {
        Order GetOrderFor(Customer customer);

        Package GetPackageFor(Order order);
    }
}
