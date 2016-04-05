using E06.Spec.Core;
using E06.Spec.Core.Models;
using Moq;
using NJasmine;
using NSpec;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E06.Spec
{
    public class A_shopping_cart : nspec
    {
        Mock<IShopRepository> repositoryMock = new Mock<IShopRepository>();
        Mock<IShopRules> rulesMock = new Mock<IShopRules>();

        void When_there_are_some_products_in_it()
        {
            rulesMock.Setup(r => r.DiscountTreshold).Returns(100);
            rulesMock.Setup(r => r.Discount).Returns(0.015);

            var cart = new ShoppingCart(rulesMock.Object, repositoryMock.Object);

            cart.Add(new Product() { Name = "milk", Price = 2.55, Quantity = 1, MinWholesaleQuantity = 100, });
            cart.Add(new Product() { Name = "potatoes", Price = 1.99, Quantity = 1.45, MinWholesaleQuantity = 100, });

            context["When checked out"] = () => {
                var payment = cart.Checkout();

                it["Should ask for payment"] = () => {
                    payment.should_not_be_null();
                };

                it["Should calculate total"] = () => {
                    payment.Total.should_be(2.55 * 1 + 1.99 * 1.45);
                };
            };
        }

        void When_empty()
        {
            var cart = new ShoppingCart(rulesMock.Object, repositoryMock.Object);

            var payment = cart.Checkout();

            it["Should not ask for anything"] = () =>
            {
                payment.should_be(PaymentRequest.NoPayment);
            };
        }

        void For_big_purchases()
        {
            rulesMock.Setup(r => r.DiscountTreshold).Returns(100);
            rulesMock.Setup(r => r.Discount).Returns(0.015);

            var cart = new ShoppingCart(rulesMock.Object, repositoryMock.Object);

            cart.Add(new Product()
            {
                Name = "TV Set",
                Price = 100.1,
                Quantity = 1,
                MinWholesaleQuantity = 100,
            });

            var payment = cart.Checkout();

            it["Should offer a discount"] = () =>
            {
                payment.Discount.should_be_greater_than(0);
            };
        }

        void For_wholesale_purchases()
        {
            it["Should offer a double discount"] = todo;
        }
    }
}
