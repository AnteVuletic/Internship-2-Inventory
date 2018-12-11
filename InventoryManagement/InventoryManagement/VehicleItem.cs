using System;
using System.Collections.Generic;
using System.Linq;
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
                    (new DateTime(2018,2 + vehicleIterator,1)),
                    usersPassed[new Random(vehicleIterator).Next(0,usersPassed.Count-1)],
                    random.Next(10000,150000));
            }

            return vehicleArray;
        }

        public Boolean IsRegistrationWithinMonth()
        {
            return DateTime.Now.Month - RegistrationDateTime.Month == 1;
        }

        public int GetRealValue()
        {
            var modifierIndex = DistanceTraveledWithVehicle/20000;
            if (modifierIndex > 8)
                modifierIndex = 8;
            return PriceOnPurchase * (1 - (modifierIndex / 10));
        }
    }
}
