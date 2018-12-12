using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class VehicleItem : Item
    {
        public DateTime RegistrationDateTime{ get; set; }
        public User VehicleUser { get; set; }
        public VehicleManufacturer Manufacturer { get; set; }
        public int DistanceTraveledWithVehicle { get; set; }

        public VehicleItem():base()
        {

        }
        public VehicleItem( string description, DateTime dateOfWarrantyEnd,
            int priceOnPurchase,DateTime dateOfPurchase, VehicleManufacturer manufacturer,DateTime registrationDateTime, string nameOfUser, string surnameOfUser,int distanceTraveledWithVehicle)
            : base( description, dateOfWarrantyEnd, priceOnPurchase, dateOfPurchase)
        {
            DistanceTraveledWithVehicle = distanceTraveledWithVehicle;
            RegistrationDateTime = registrationDateTime;
            VehicleUser.NameOfUser = nameOfUser;
            VehicleUser.SurnameOfUser = surnameOfUser;
        }
        public VehicleItem( string description, DateTime dateOfWarrantyEnd,
            int priceOnPurchase,DateTime dateOfPurchase , VehicleManufacturer manufacturer, DateTime registrationDateTime, User vehicleUser, int distanceTraveledWithVehicle)
            : base( description, dateOfWarrantyEnd, priceOnPurchase, dateOfPurchase)
        {
            DistanceTraveledWithVehicle = distanceTraveledWithVehicle;
            RegistrationDateTime = registrationDateTime;
            VehicleUser = vehicleUser;
            Manufacturer = manufacturer;
        }

        public void PrintVehicleInfo()
        {
            Console.WriteLine(" _______________________________________________ ");
            Console.WriteLine("                                 ");
            Console.WriteLine($" Vehicle guid: {SerialNumberGuid}");
            Console.WriteLine($" User of vehicle ID: {VehicleUser.IdUser}");
            Console.WriteLine($" User of vehicle name: {VehicleUser.NameOfUser}");
            Console.WriteLine($" User of vehicle surname: {VehicleUser.SurnameOfUser}");
            Console.WriteLine($" Vehicle Model: {Manufacturer}");
            Console.WriteLine($" Vehicle distance ran: {DistanceTraveledWithVehicle} km");
            Console.WriteLine($" Registration date: {RegistrationDateTime.Day}/{RegistrationDateTime.Month}");
            Console.WriteLine($" Vehicle description: {Description}");
            Console.WriteLine($" Vehicle warranty end: {DateOfWarrantyEnd.Month}/{DateOfWarrantyEnd.Year}");
            Console.WriteLine($" Vehicle price on purchase: {PriceOnPurchase} $");
            Console.WriteLine($" Vehicle date of purchase: {DateOfPurchase.Month}/{DateOfPurchase.Year}");
            Console.WriteLine("________________________________________________");
            Console.WriteLine();
        }

        public VehicleItem AddVehicle(List<User> argListOfUsers)
        {
            var stagingVehicle = new VehicleItem();
            Console.WriteLine("Please enter the id of the intended user of this vehicle:");
            var idInputed = int.Parse(Console.ReadLine());
            foreach (var user in argListOfUsers)
            {
                if (user.IdUser == idInputed)
                    stagingVehicle.VehicleUser = user;
            }
            Console.WriteLine("Please enter the vehicle manufacturer:");
            var manufacturerString = Console.ReadLine();
            if (Enum.TryParse(manufacturerString, out VehicleManufacturer tmpManufacturer))
                stagingVehicle.Manufacturer = tmpManufacturer;
            else
                Console.WriteLine("Not an manufacturer we support");
            Console.WriteLine("What is the total distance traveled of the vehicle:");
            stagingVehicle.DistanceTraveledWithVehicle = int.Parse(Console.ReadLine());
            Console.WriteLine("You will be prompted to entered values regarding vehicle registration date.");
            try
            {
                Console.WriteLine("Please enter month of registration date:");
                var monthOfReg = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter day of registration date:");
                var dayOfReg = int.Parse(Console.ReadLine());
                stagingVehicle.RegistrationDateTime = new DateTime(2000, monthOfReg, dayOfReg);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! Was expecting number values.");
                stagingVehicle.RegistrationDateTime =  new DateTime(9999, 99, 99);
            }
            Console.WriteLine("Please enter an description of the vehicle:");
            stagingVehicle.Description = Console.ReadLine();
            Console.WriteLine("You will be prompted to enter values regarding vehicle warranty date.");
            stagingVehicle.DateOfWarrantyEnd = TestDateTimeInput();
            Console.WriteLine("Please enter the vehicles price when purchased.");
            stagingVehicle.PriceOnPurchase = int.Parse(Console.ReadLine());
            stagingVehicle.DateOfPurchase = DateTime.Now;
            return stagingVehicle;

        }
        public VehicleItem[] FillVehiclesWithDummyValues(List<User> usersPassed)
        {
            var vehicleArray = new VehicleItem[10];
            for (var vehicleIterator = 0; vehicleIterator < vehicleArray.Length; vehicleIterator ++)
            {
                var values = Enum.GetValues(typeof(VehicleManufacturer));
                var random = new Random(vehicleIterator);
                VehicleManufacturer randomManufacturer = (VehicleManufacturer) values.GetValue(random.Next(0, values.Length));
                vehicleArray[vehicleIterator] = new VehicleItem(
                    ("This is an dummy description for vehicle " + vehicleIterator),
                    (new DateTime(2018,1+vehicleIterator,1)),
                    (1000 * (1+vehicleIterator)),
                    (new DateTime(2017,1+vehicleIterator,1)),
                    randomManufacturer,
                    (new DateTime(2018,2 + vehicleIterator,5+vehicleIterator)),
                    usersPassed[new Random(vehicleIterator).Next(0,usersPassed.Count-1)],
                    random.Next(10000,150000));
            }
            return vehicleArray;
        }

        public Boolean IsRegistrationWithinMonth()
        {
            if (RegistrationDateTime.Month == 1 && DateTime.Now.Month == 12)
                return true;
            return (int)(RegistrationDateTime.Month - DateTime.Now.Month) == 1;
        }

        public int GetRealValue()
        {
            var modifierIndex = (double)DistanceTraveledWithVehicle/20000;
            if ((int)modifierIndex == 0)
                return PriceOnPurchase;
            modifierIndex /= 10;
            if (modifierIndex > 0.8)
                modifierIndex = 0.8;
            return (int)(PriceOnPurchase * modifierIndex);
        }
    }
}
