using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class TechnologyItem : Item
    {
        public Boolean BatteryBoolean { get; set; }

        public TechnologyItem()
        {

        }
        public TechnologyItem(string description, DateTime dateOfWarrantyEnd,
            int priceOnPurchase, DateTime dateOfPurchase, Boolean batteryBoolean)
            : base(description, dateOfWarrantyEnd, priceOnPurchase, dateOfPurchase)
        {
            BatteryBoolean = batteryBoolean;
        }
    }
}
