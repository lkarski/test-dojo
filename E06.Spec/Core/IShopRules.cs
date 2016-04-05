using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E06.Spec.Core
{
    public interface IShopRules
    {
        double DiscountTreshold { get; set; }

        double Discount { get; set; }
    }
}
