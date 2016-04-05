using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E03.DependencyBreaking.WebServiceContract
{
    public class ShopWebClient : IShopClient
    {
        public PaymentResponse RequestPayment(PaymentRequest request)
        {
            throw new ApplicationException("Could not connect to remote endpoint. Service unavailable.");
        }
    }
}
