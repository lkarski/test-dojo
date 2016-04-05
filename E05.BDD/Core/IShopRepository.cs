using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E05.BDD.Core
{
    public interface IShopRepository
    {
        void Save(ShoppingCart cart);
    }
}
