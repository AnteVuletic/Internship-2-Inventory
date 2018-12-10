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

        public MobilephoneTechnologyItem(Guid serialNumberGuid, string description,
            TimeSpan monthsOfWarrantyRemainingTimeSpan,
            int priceOnPurchase, int manufacturer, Boolean batteryBoolean, string phoneNumber, string nameOfUser,
            string surnameOfUser)
            : base(serialNumberGuid, description, monthsOfWarrantyRemainingTimeSpan, priceOnPurchase, manufacturer,
                batteryBoolean)
        {
            PhoneNumber = phoneNumber;
            MobilephoneUser.NameOfUser = nameOfUser;
            MobilephoneUser.SurnameOfUser = surnameOfUser;
        }
        public MobilephoneTechnologyItem(Guid serialNumberGuid, string description,
            TimeSpan monthsOfWarrantyRemainingTimeSpan,
            int priceOnPurchase, int manufacturer, Boolean batteryBoolean, string phoneNumber, User mobilephoneUser)
            : base(serialNumberGuid, description, monthsOfWarrantyRemainingTimeSpan, priceOnPurchase, manufacturer,
                batteryBoolean)
        {
            PhoneNumber = phoneNumber;
            MobilephoneUser = mobilephoneUser;
        }
    }
}
