using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class ComputerTechnologyItem : TechnologyItem
    {
        public int OperatingSystem { get; set; }
        public Boolean Portable { get; set; }

        public ComputerTechnologyItem(Guid serialNumberGuid, string description,
            TimeSpan monthsOfWarrantyRemainingTimeSpan,
            int priceOnPurchase, int manufacturer, Boolean batteryBoolean, int operatingSystem, Boolean portable)
            : base(serialNumberGuid, description, monthsOfWarrantyRemainingTimeSpan, priceOnPurchase, manufacturer,
                batteryBoolean)
        {
            OperatingSystem = operatingSystem;
            Portable = portable;
        }

    }
}
