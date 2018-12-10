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
        public MobilephoneTechnologyItem(MobilephoneManufacturer manufacturer,string description,
            DateTime dateOfWarrantyEnd,
            int priceOnPurchase, Boolean batteryBoolean, string phoneNumber, string nameOfUser,
            string surnameOfUser)
            : base(description, dateOfWarrantyEnd, priceOnPurchase,
                batteryBoolean)
        {
            PhoneNumber = phoneNumber;
            MobilephoneUser.NameOfUser = nameOfUser;
            MobilephoneUser.SurnameOfUser = surnameOfUser;
            Manufacturer = manufacturer;
        }
        public MobilephoneTechnologyItem(MobilephoneManufacturer manufacturer,string description,
            DateTime dateOfWarrantyEnd,
            int priceOnPurchase, Boolean batteryBoolean, string phoneNumber, User mobilephoneUser)
            : base(description, dateOfWarrantyEnd, priceOnPurchase,
                batteryBoolean)
        {
            PhoneNumber = phoneNumber;
            MobilephoneUser = mobilephoneUser;
            Manufacturer = manufacturer;
        }
        public MobilephoneTechnologyItem[] FillMobilesphonesWithDummyItems(User[] usersPassed)
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
                    randomManufacturer,
                    ("This is an dummy description of an mobile phone:" + mobileIterator),
                    (new DateTime(2019,1+mobileIterator,1)),
                    (1000 * (mobileIterator+1)),
                    true,
                    ("09"+randomStringForNumber),
                    usersPassed[new Random(mobileIterator).Next(0,usersPassed.Length)]);
                
            }

            return mobilephoneArray;
        }

    }
}
