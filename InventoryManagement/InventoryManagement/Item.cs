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
            SerialNumberGuid = Guid.NewGuid();
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

        public DateTime TestDateTimeInput()
        {
            try
            {
                Console.WriteLine("Please enter year of date:");
                var year = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter month of date:");
                var month = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter day of date");
                var day = int.Parse(Console.ReadLine());
                return new DateTime(year, month, day);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! Was expecting number values.");
                return new DateTime(9999,99,99);
            }
        }
        public Boolean IsGuid(string argPassedGuid)
        {
            return SerialNumberGuid.ToString().Contains(argPassedGuid);
        }

        public Boolean IsWarrantyEndYear(DateTime argYearPassed)
        {
            return DateOfWarrantyEnd.Year == argYearPassed.Year;
        }
    }
}
