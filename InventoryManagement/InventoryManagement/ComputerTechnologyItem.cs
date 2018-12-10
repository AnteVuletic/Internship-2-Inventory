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
        public ComputerManufacturer Manufacturer { get; set; }

        public ComputerTechnologyItem()
        {

        }
        public ComputerTechnologyItem(string description,DateTime dateOfWarrantyEnd,
            int priceOnPurchase, ComputerManufacturer manufacturer, Boolean batteryBoolean, OperatingSystems operatingSystem, Boolean portable)
            : base(description, dateOfWarrantyEnd, priceOnPurchase,
                batteryBoolean)
        {
            OperatingSystem = operatingSystem;
            Portable = portable;
            Manufacturer = manufacturer;
        }

        public ComputerTechnologyItem[] FillComputerTechnologyWithDummyItems()
        {
            var computerArray = new ComputerTechnologyItem[10];
            for (var computerIterator = 0; computerIterator < computerArray.Length ; computerIterator++)
            {
                var valuesOfCompManufacturers = Enum.GetValues(typeof(ComputerManufacturer));
                var valuesOfOperatingSystems = Enum.GetValues(typeof(OperatingSystems));
                var random = new Random(computerIterator);
                ComputerManufacturer randomComputerManufacturer =
                    (ComputerManufacturer) valuesOfCompManufacturers.GetValue(random.Next(0,
                        valuesOfCompManufacturers.Length));
                OperatingSystems randomOperatingSystem =
                    (OperatingSystems) valuesOfOperatingSystems.GetValue(
                        random.Next(0, valuesOfOperatingSystems.Length));
                var batteryAndPortableInterchange = computerIterator % 2 == 0;

                computerArray[computerIterator] = new ComputerTechnologyItem(
                    ("This is just an dummy description for computer " + computerIterator),
                    (new DateTime(2019, 1 + computerIterator, 1)),
                    (1000 * (computerIterator + 1)),
                    randomComputerManufacturer,
                    batteryAndPortableInterchange,
                    randomOperatingSystem,
                    batteryAndPortableInterchange);

            }

            return computerArray;
        }
    }
}
