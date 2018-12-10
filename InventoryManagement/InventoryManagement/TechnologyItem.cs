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

        public TechnologyItem(Guid serialNumberGuid, string description, TimeSpan monthsOfWarrantyRemainingTimeSpan,
            int priceOnPurchase, Manufacturer manufacturer, Boolean batteryBoolean)
            : base(serialNumberGuid, description, monthsOfWarrantyRemainingTimeSpan, priceOnPurchase, manufacturer)
        {
            BatteryBoolean = batteryBoolean;
        }
    }
}
