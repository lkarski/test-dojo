using E04.Moq.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.Moq.Core
{
    public class ShoppingCart : List<Product>
    {
        IShopRules rules;
        IShopRepository repository;
        CustomerService customerService;

        public ShoppingCart(IShopRules rules, IShopRepository repository, CustomerService customerService)
        {
            this.rules = rules;
            this.repository = repository;
            this.customerService = customerService;
        }

        public PaymentRequest Checkout()
        {
            var cart = this;
            double total = 0;
            bool isWholesale = true;

            if (Count == 0) return PaymentRequest.NoPayment;

            repository.Save(cart);

            foreach (var product in cart)
            {
                isWholesale &= product.Quantity >= product.MinWholesaleQuantity;
                total += product.Price * product.Quantity;
            }

            PaymentRequest request = new PaymentRequest();

            if (total > rules.DiscountTreshold)
            {
                var discount = rules.Discount;

                if (isWholesale) discount = discount * 2;

                request.Total = total * (1 - discount);
                request.Discount = discount;
            }
            else
            {
                request.Total = total;
            }

            if (customerService.CartQualifiesForLoyaltyPoints(cart))
            {
                customerService.AwardLoyaltyPointsFor(cart);
            }

            return request;
        }
        
    }
}
