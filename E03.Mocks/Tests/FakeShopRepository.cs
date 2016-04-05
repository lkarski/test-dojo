using E04.Moq.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E04.Moq.Tests
{
    class FakeShopRepository : IShopRepository
    {
        public FakeShopRepository()
        {
            SavedCarts = new List<ShoppingCart>();
        }

        public List<ShoppingCart> SavedCarts { get; set; }

        public void Save(ShoppingCart cart)
        {
            SavedCarts.Add(cart);
        }
    }
}
