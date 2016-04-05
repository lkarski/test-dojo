using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E03.DependencyBreaking.WebServiceContract
{
    public interface IShopClient
    {
        PaymentResponse RequestPayment(PaymentRequest request);
    }
}
