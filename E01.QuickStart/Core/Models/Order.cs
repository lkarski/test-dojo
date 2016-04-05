using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.QuickStart.Core.Models
{
    public class Order
    {
        public Order()
        {
            Products = new List<string>();
        }

        public string Number { get; set; }

        public List<string> Products { get; set; }

        public bool IsReady { get; set; }

        public string DeliveryDelayReason { get; set; }

        public Package Package { get; set; }
    }
}
