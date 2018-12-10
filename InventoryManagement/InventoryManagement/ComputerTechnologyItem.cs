using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class ComputerTechnologyItem : TechnologyItem
    {
        public OperatingSystems OperatingSystem { get; set; }
        public Boolean Portable { get; set; }

        public ComputerTechnologyItem(Guid serialNumberGuid, string description,
            TimeSpan monthsOfWarrantyRemainingTimeSpan,
            int priceOnPurchase, Manufacturer manufacturer, Boolean batteryBoolean, OperatingSystems operatingSystem, Boolean portable)
            : base(serialNumberGuid, description, monthsOfWarrantyRemainingTimeSpan, priceOnPurchase, manufacturer,
                batteryBoolean)
        {
            OperatingSystem = operatingSystem;
            Portable = portable;
        }

    }
}
