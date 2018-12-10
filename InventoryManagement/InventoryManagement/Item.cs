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
        public static Guid SerialNumberGuid { get; set; }
        public string Description { get; set; }
        public DateTime DateOfWarrantyEnd { get; set; }
        public int PriceOnPurchase { get; set; }

        public Item()
        {

        }
        public Item(string description, DateTime dateOfWarrantyEnd,
            int priceOnPurchase)
        {
            SerialNumberGuid = Guid.NewGuid();
            Description = description;
            DateOfWarrantyEnd = dateOfWarrantyEnd;
            PriceOnPurchase = priceOnPurchase;
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
            Console.WriteLine($"Months left until warranty is finished:{(DateOfWarrantyEnd.Month - DateTime.Now.Month)} ");
        }

        public void PrintPriceOnPurchase()
        {
            Console.WriteLine("Price on purchase was: " + PriceOnPurchase);
        }
    }
}
