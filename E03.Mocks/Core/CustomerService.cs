using E04.Moq.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.Moq.Core
{
    public class CustomerService
    {
        public virtual bool CartQualifiesForLoyaltyPoints(ShoppingCart cart)
        {
            return cart.Count > 2;
        }

        public virtual void AwardLoyaltyPointsFor(ShoppingCart cart)
        {
            #region compute loyaly points and award them to the customer
            
            #endregion
        }
    }
}
