using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Item
    {
        public Guid SerialNumberGuid { get; set; }
        public string Description { get; set; }
        public TimeSpan MonthsOfWarrantyRemainingTimeSpan { get; set; }
        public int PriceOnPurchase { get; set; }
        public int Manufacturer { get; set; }

        public Item(Guid serialNumberGuid, string description, TimeSpan monthsOfWarrantyRemainingTimeSpan,
            int priceOnPurchase, int manufacturer)
        {
            SerialNumberGuid = serialNumberGuid;
            Description = description;
            MonthsOfWarrantyRemainingTimeSpan = monthsOfWarrantyRemainingTimeSpan;
            PriceOnPurchase = priceOnPurchase;
            Manufacturer = manufacturer;
        }
    }
}
