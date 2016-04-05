Requirements
============

Customer fills his shopping cart with some products and goes to checkout.

On checkout we calculate total amount to be paid based on the price 
and quantity of each of the products in the cart. This amount is requested
from the customer. 

If a customer makes a big purchase exceeding $300 we offer them a 1.5% 
discount. During Xmas it's $400 and 0.75% discount. The total amount is 
decreased by the discuount and the discount is also happily communicated 
to the customer along with to total amount to be paid.

We also offer wholesale option. For each product there is a wholesale amount 
and if a customer buys more than that and qualifies for a discount then he 
is offered a double discount.

When the cart is empty we obviously request no payment from the customer and we 
let him through.

Setup
=====

Install NUnit via Package Manager Console

	PM> Install-Package NUnitTestAdapter.WithFramework -ProjectName E04.TDD

