using E04.Moq.Core;
using E04.Moq.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.Moq.Tests
{
    class ShoppingCartTests
    {
        [Test]
        public void Checkout_ShouldSaveCart_IfItIsNotEmpty()
        {
            // Arrange
            var fakeRules = new FakeShopRules();
            var fakeRepository = new FakeShopRepository();
            var cart = new ShoppingCart(fakeRules, fakeRepository, new CustomerService());
            cart.Add(new Product() { Price = 10.12, Quantity = 150 });

            // Act
            var result = cart.Checkout();

            // Assert
            Assert.That(cart, Is.EqualTo(fakeRepository.SavedCarts[0]));
        }

        [Test]
        public void Checkout_ShouldDoubleTheDiscount_OnWholesale()
        {
            // Arrange
            var discount = 0.015;

            var fakeRules = new FakeShopRules() { Discount = discount, DiscountTreshold = 1000 };
            var fakeRepository = new FakeShopRepository();

            var cart = new ShoppingCart(fakeRules, fakeRepository, new CustomerService());
            cart.Add(new Product() { Price = 10.12, Quantity = 150, MinWholesaleQuantity = 100 });

            // Act
            var result = cart.Checkout();

            // Assert
            Assert.That(result.Discount, Is.EqualTo(discount * 2));
            Assert.That(result.Total, Is.EqualTo(10.12 * 150 * (1 - (discount * 2))));
        }

        [Test]
        public void Checkout_ShouldAwardLoyaltyPoints_IfCartIsEligible()
        {
            // Arrange
            var fakeRules = new FakeShopRules();
            var fakeRepository = new FakeShopRepository();
           
            var cart = new ShoppingCart(fakeRules, fakeRepository, new CustomerService());

            cart.Add(new Product() { Price = 1234.5, Quantity = 3, MinWholesaleQuantity = 2 });

            // Act
            var result = cart.Checkout();

            // Assert
            // ???
        }

        [Test, Ignore]
        public void Checkout_ShouldNotAwardLoyaltyPoints_WhenCartIsEmpty()
        {
        }
    }
}
