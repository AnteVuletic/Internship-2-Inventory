using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Vehicle : Item
    {
        public DateTime RegistrationDateTime{ get; set; }
        public User VehicleUser { get; set; }

        public Vehicle(Guid serialNumberGuid, string description, TimeSpan monthsOfWarrantyRemainingTimeSpan,
            int priceOnPurchase, Manufacturer manufacturer,DateTime registrationDateTime, string nameOfUser, string surnameOfUser)
            : base(serialNumberGuid, description, monthsOfWarrantyRemainingTimeSpan, priceOnPurchase, manufacturer)
        {
            RegistrationDateTime = registrationDateTime;
            VehicleUser.NameOfUser = nameOfUser;
            VehicleUser.SurnameOfUser = surnameOfUser;
        }
        public Vehicle(Guid serialNumberGuid, string description, TimeSpan monthsOfWarrantyRemainingTimeSpan,
            int priceOnPurchase, Manufacturer manufacturer, DateTime registrationDateTime, User vehicleUser)
            : base(serialNumberGuid, description, monthsOfWarrantyRemainingTimeSpan, priceOnPurchase, manufacturer)
        {
            RegistrationDateTime = registrationDateTime;
            VehicleUser = vehicleUser;
        }
    }
}
