using E06.Spec.Core;
using E06.Spec.Core.Models;
using Moq;
using NJasmine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E06.Spec
{
    public class NJasmineShoppingCartSpecs : GivenWhenThenFixture
    {
        Mock<IShopRepository> repositoryMock = new Mock<IShopRepository>();
        Mock<IShopRules> rulesMock = new Mock<IShopRules>();

        public override void Specify()
        {
            rulesMock.Setup(r => r.DiscountTreshold).Returns(100);
            rulesMock.Setup(r => r.Discount).Returns(0.015);

            describe("A shopping cart", () =>
            {
                when("there are some products in it", () =>
                {
                    var cart = new ShoppingCart(rulesMock.Object, repositoryMock.Object);

                    cart.Add(new Product() { Name = "milk", Price = 2.55, Quantity = 1, MinWholesaleQuantity = 100 });
                    cart.Add(new Product() { Name = "potatoes", Price = 1.99, Quantity = 1.45, MinWholesaleQuantity = 100 });

                    when("submitted", () =>
                    {
                        var payment = cart.Checkout();

                        it("should ask for payment", () =>
                        {
                            expect(() => payment != null);
                        });

                        it("should calculate total", () =>
                        {
                            expect(() => payment.Total == 2.55 * 1 + 1.99 * 1.45);
                        });
                    });
                });

                when("the cart is empty", () =>
                {
                    var cart = new ShoppingCart(rulesMock.Object, repositoryMock.Object);

                    var payment = cart.Checkout();

                    it("should not ask for payment", () => {
                        expect(() => payment == PaymentRequest.NoPayment);
                    });
                });

                when("doing a big purchase", () =>
                {
                    var cart = new ShoppingCart(rulesMock.Object, repositoryMock.Object);

                    cart.Add(new Product() { Name = "TV Set", Price = 100.1, Quantity = 1, MinWholesaleQuantity = 100 });

                    var payment = cart.Checkout();

                    it("should offer a discount", () =>
                    {
                        expect(() => payment.Discount > 0);
                    });
                });

                when("buying wholesale amount of products", () =>
                {
                    it("should offer double discount"); // PENDING
                });
            });
        }
    }
}

/*
    A shopping cart
        when there are some products in it
            when submitted
                it should ask for payment
                it should calculate total
        when the cart is empty
            it should not ask for payment
        when doing a big purchase
            it should offer a discount
        when buying wholesale amount of products
            it should offer double discount

    5 Examples, 0 Failed, 0 Pending
*/