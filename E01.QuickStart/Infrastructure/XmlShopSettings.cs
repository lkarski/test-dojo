using E01.QuickStart.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace E01.QuickStart.Infrastructure
{
    public class XmlShopSettings : IShopSettings
    {
        public int LoyaltyBonusLevel { 
            get 
            {
                // read external xml file
                Thread.Sleep(1000);

                return 3; 
            } 
        }
    }
}
