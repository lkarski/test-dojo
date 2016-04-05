using E04.Moq.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E04.Moq.Tests
{
    class FakeShopRules : IShopRules
    {
        public double DiscountTreshold { get; set; }

        public double Discount { get; set; }
    }
}
