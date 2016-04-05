using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E05.BDD.Core.Models
{
    public class PaymentRequest
    {
        public static readonly PaymentRequest NoPayment = new PaymentRequest();

        public double Total { get; set; }

        public double Discount { get; set; }
    }
}
