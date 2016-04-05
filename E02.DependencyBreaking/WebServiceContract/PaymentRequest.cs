using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E03.DependencyBreaking.WebServiceContract
{
    public class PaymentRequest
    {
        public PaymentRequest()
        {
            Total = double.NaN;
            Discount = double.NaN;
        }

        public double Total { get; set; }

        public double Discount { get; set; }
    }
}
