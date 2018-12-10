using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public Manufacturer Manufacturer { get; set; }

        public Item(Guid serialNumberGuid, string description, TimeSpan monthsOfWarrantyRemainingTimeSpan,
            int priceOnPurchase, Manufacturer manufacturer)
        {
            SerialNumberGuid = serialNumberGuid;
            Description = description;
            MonthsOfWarrantyRemainingTimeSpan = monthsOfWarrantyRemainingTimeSpan;
            PriceOnPurchase = priceOnPurchase;
            Manufacturer = manufacturer;
        }

        public void PrintSerialNumber()
        {
            Console.WriteLine("Serial number of the item is: " + SerialNumberGuid);
        }

        public void PrintDescription()
        {
            Console.WriteLine("Description of item is: " + Description);
        }

        public void PrintMonthsLeftUntilEndOfWarranty()
        {
            Console.WriteLine("Months left until warranty is finished: " + MonthsOfWarrantyRemainingTimeSpan);
        }

        public void PrintPriceOnPurchase()
        {
            Console.WriteLine("Price on purchase was: " + PriceOnPurchase);
        }
    }
}
