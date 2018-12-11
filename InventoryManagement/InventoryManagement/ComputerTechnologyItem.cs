using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
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
            int priceOnPurchase,DateTime dateOfPurchase, ComputerManufacturer manufacturer, Boolean batteryBoolean, OperatingSystems operatingSystem, Boolean portable)
            : base(description, dateOfWarrantyEnd, priceOnPurchase, dateOfPurchase, batteryBoolean)
        {
            OperatingSystem = operatingSystem;
            Portable = portable;
            Manufacturer = manufacturer;
        }

        public void PrintComputerInfo()
        {
            Console.WriteLine(" _______________________________________________ ");
            Console.WriteLine("                                 ");
            Console.WriteLine($" Computer guid: {SerialNumberGuid}");
            Console.WriteLine(Portable ? $" Computer is portable." : $" Computer is not portable");
            Console.WriteLine($" Computer OS is: {OperatingSystem}");
            Console.WriteLine($" Computer manufacturer: {Manufacturer}");
            Console.WriteLine($" Computer description: {Description}");
            Console.WriteLine($" Computer warranty end: {DateOfWarrantyEnd.Month}/{DateOfWarrantyEnd.Year}");
            Console.WriteLine($" Computer price on purchase: {PriceOnPurchase} $");
            Console.WriteLine($" Computer date of purchase: {DateOfPurchase.Month}/{DateOfPurchase.Year}");
            Console.WriteLine("________________________________________________");
            Console.WriteLine();
        }

        public ComputerTechnologyItem AddComputer()
        {
            var stagingComputer = new ComputerTechnologyItem();
            Console.WriteLine("Please enter manufacturer of the computer:");
            var manufacturerString = Console.ReadLine();
            if (Enum.TryParse(manufacturerString, out ComputerManufacturer tmpManufacturer))
                stagingComputer.Manufacturer = tmpManufacturer;
            else
                Console.WriteLine("Not an manufacturer we support");
            Console.WriteLine("Please enter the OS of the computer:");
            var operatingSystem = Console.ReadLine();
            if (Enum.TryParse(operatingSystem, out OperatingSystems tmpOperatingSystems))
                stagingComputer.OperatingSystem = tmpOperatingSystems;
            else
                Console.WriteLine("Not an Operating system we support.");
            Console.WriteLine("Please enter an description of the computer:");
            stagingComputer.Description = Console.ReadLine();
            Console.WriteLine("You will be prompted to enter values regarding warranty.");
            stagingComputer.DateOfWarrantyEnd = TestDateTimeInput();
            Console.WriteLine("Please enter purchase price:");
            stagingComputer.PriceOnPurchase = int.Parse(Console.ReadLine());
            stagingComputer.DateOfPurchase = DateTime.Now;
            Console.WriteLine("Is the computer portable: y[es]/n[o]");
            stagingComputer.Portable = Console.ReadKey().Key == ConsoleKey.Y;
            Console.WriteLine();
            Console.WriteLine("Does the computer have an battery: y[es]/n[o]");
            stagingComputer.BatteryBoolean = Console.ReadKey().Key == ConsoleKey.Y;
            Console.WriteLine();
            return stagingComputer;

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
                    (new DateTime(2017, 1 + computerIterator, 1)),
                    randomComputerManufacturer, 
                    batteryAndPortableInterchange,
                    randomOperatingSystem,
                    batteryAndPortableInterchange);
            }
            return computerArray;
        }

        public Boolean IsManufacturer(string argManufacturerPassed)
        {
            if (!Enum.GetNames(typeof(ComputerManufacturer)).Contains(argManufacturerPassed))
                return false;
            return Manufacturer.ToString() == argManufacturerPassed;
        }

        public int GetRealValue()
        {
            var monthsPassed = DateOfPurchase - DateTime.Now;
            var modifierIndex = ((int)(monthsPassed.TotalDays) / 30) * 0.05;
            if (modifierIndex > 0.7) modifierIndex = 0.7;
            return (int)(PriceOnPurchase * modifierIndex);
        }
    }
}
