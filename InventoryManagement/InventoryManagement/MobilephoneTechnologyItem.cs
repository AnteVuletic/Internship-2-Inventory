using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class MobilephoneTechnologyItem : TechnologyItem
    {
        public string PhoneNumber { get; set; }
        public User MobilephoneUser { get; set; }
        public MobilephoneManufacturer Manufacturer { get; set; }

        public MobilephoneTechnologyItem():base()
        {

        }
        public MobilephoneTechnologyItem(string description,
            DateTime dateOfWarrantyEnd,int priceOnPurchase, DateTime dateOfPurchase, Boolean batteryBoolean, MobilephoneManufacturer manufacturer, string phoneNumber, string nameOfUser,
            string surnameOfUser)
            : base(description, dateOfWarrantyEnd, priceOnPurchase, dateOfPurchase,
                batteryBoolean)
        {
            PhoneNumber = phoneNumber;
            MobilephoneUser.NameOfUser = nameOfUser;
            MobilephoneUser.SurnameOfUser = surnameOfUser;
            Manufacturer = manufacturer;
        }
        public MobilephoneTechnologyItem(string description,
            DateTime dateOfWarrantyEnd,int priceOnPurchase, DateTime dateOfPurchase, Boolean batteryBoolean, MobilephoneManufacturer manufacturer, string phoneNumber, User mobilephoneUser)
            : base(description, dateOfWarrantyEnd, priceOnPurchase, dateOfPurchase,
                batteryBoolean)
        {
            PhoneNumber = phoneNumber;
            MobilephoneUser = mobilephoneUser;
            Manufacturer = manufacturer;
        }
        public void PrintMobilephoneInfo()
        {
            Console.WriteLine(" _______________________________________________ ");
            Console.WriteLine("                                 ");
            Console.WriteLine($" Vehicle guid: {SerialNumberGuid}");
            Console.WriteLine($" User of mobilephone ID: {MobilephoneUser.IdUser}");
            Console.WriteLine($" User of mobilephone name: {MobilephoneUser.NameOfUser}");
            Console.WriteLine($" User of mobilephone surname: {MobilephoneUser.SurnameOfUser}");
            Console.WriteLine($" Mobile phonenumber: {PhoneNumber}");
            Console.WriteLine($" Mobilephone Model: {Manufacturer}");
            Console.WriteLine($" Mobilephone description: {Description}");
            Console.WriteLine($" Mobilephone warranty end: {DateOfWarrantyEnd.Month}/{DateOfWarrantyEnd.Year}");
            Console.WriteLine($" Mobilephone price on purchase: {PriceOnPurchase} $");
            Console.WriteLine($" Mobilephone date of purchase: {DateOfPurchase.Month}/{DateOfPurchase.Year}");
            Console.WriteLine("________________________________________________");
            Console.WriteLine();
        }
        public MobilephoneTechnologyItem[] FillMobilesphonesWithDummyItems(List<User> usersPassed)
        {
            var mobilephoneArray = new MobilephoneTechnologyItem[10];
            for (var mobileIterator = 0; mobileIterator < mobilephoneArray.Length; mobileIterator++)
            {
                var values = Enum.GetValues(typeof(MobilephoneManufacturer));
                var random = new Random(mobileIterator);
                MobilephoneManufacturer randomManufacturer = (MobilephoneManufacturer)values.GetValue(random.Next(0, values.Length));
                var randomStringForNumber = "";
                for (var digitIndex = 0; digitIndex < 6; digitIndex++)
                {
                    randomStringForNumber += (random.Next(0, 9)).ToString();
                }
                mobilephoneArray[mobileIterator] = new MobilephoneTechnologyItem(
                    ("This is an dummy description of an mobile phone:" + mobileIterator),
                    (new DateTime(2019,1+mobileIterator,1)),
                    (100 * (mobileIterator+1)),
                    (new DateTime(2018, 1 + mobileIterator, 1)),
                    true,
                    randomManufacturer,
                    ("09"+randomStringForNumber),
                    usersPassed[new Random(mobileIterator).Next(0,usersPassed.Count-1)]);
                
            }
            return mobilephoneArray;
        }

        public Boolean IsManufacturer(string argManufacturerPassed)
        {
            if (!Enum.GetNames(typeof(MobilephoneManufacturer)).Contains(argManufacturerPassed))
                return false;

            return Manufacturer.ToString() == argManufacturerPassed;
        }

    }
}
