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
        public int GetRealValue()
        {
            var monthsPassed = DateTime.Now - DateOfPurchase;
            var modifierIndex = (double)(((monthsPassed.TotalDays/30)) * 0.05);
            modifierIndex = 1 - modifierIndex;
            if (modifierIndex < 0.3) modifierIndex = 0.3;
            return (int)(PriceOnPurchase * modifierIndex);
        }
    }
}
