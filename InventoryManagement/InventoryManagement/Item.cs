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
        public Guid SerialNumberGuid { get; private set; }
        public string Description { get; set; }
        public DateTime DateOfWarrantyEnd { get; set; }
        public int PriceOnPurchase { get; set; }
        public DateTime DateOfPurchase { get; set; }

        public Item()
        {

        }
        public Item(string description, DateTime dateOfWarrantyEnd,
            int priceOnPurchase,DateTime dateOfPurchase)
        {
            SerialNumberGuid = Guid.NewGuid();
            Description = description;
            DateOfWarrantyEnd = dateOfWarrantyEnd;
            PriceOnPurchase = priceOnPurchase;
            DateOfPurchase = dateOfPurchase;
        }

        public Boolean IsGuid(Guid argPassedGuid)
        {
            return SerialNumberGuid == argPassedGuid;
        }

        public Boolean IsWarrantyEndYear(DateTime argYearPassed)
        {
            return DateOfWarrantyEnd.Year == argYearPassed.Year;
        }
    }
}
