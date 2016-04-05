using E01.QuickStart.Core.Models;
using E01.QuickStart.Core.PickupResults;
using E01.QuickStart.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.QuickStart.Core
{
    public class ShopAssistant
    {
        IShopRepository repository;
        IShopSettings settings;
        CustomerService customerService;

        public ShopAssistant()
            : this(new SqlShopRepository(), new XmlShopSettings(), new CustomerService())
        {

        }

        public ShopAssistant(IShopRepository repository, IShopSettings settings, CustomerService roomService)
        {
            this.repository = repository;
            this.settings = settings;
            this.customerService = roomService;
        }

        public PickupResult PickupOrder(Customer customer)
        {
            Order order = repository.GetOrderFor(customer);

            if (order == null)
            {
                return new OrderNotFound()
                {
                    Message = "Are you sure? When and how did you make an order?"
                };
            }

            if (!order.IsReady)
            {
                return new PickupRefused()
                {
                    Message = "I'm sorry. Your order is not ready yet due to " + order.DeliveryDelayReason
                };
            }

            var package = repository.GetPackageFor(order);

            if (customer.Loyalty > settings.LoyaltyBonusLevel)
            {
                customerService.AddBonusPackFor(order);
            }

            return new PickupConfirmation()
            {
                Message = "Here you are!",
                Package = package
            };
        }
    }
}
