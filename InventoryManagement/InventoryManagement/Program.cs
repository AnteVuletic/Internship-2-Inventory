using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userArray = new User().FillWithDummyUsers();
            var vehicleArray = new VehicleItem().FillVehiclesWithDummyValues(userArray);
            var mobilephoneArray = new MobilephoneTechnologyItem().FillMobilesphonesWithDummyItems(userArray);
            var computerArray = new ComputerTechnologyItem().FillComputerTechnologyWithDummyItems();
        }
    }

    public enum VehicleManufacturer
    {
        Toyota,
        Mercedes,
        Audi,
        Skoda,
        Opel,
        LandRover,
        RangeRover,
        Fiat,
        Nissan
    }

    public enum MobilephoneManufacturer
    {
        Lenovo,
        Samsung,
        Apple,
        Motorola,
        Pocophone,
        Gsmart,
        Huawei
    }

    public enum ComputerManufacturer
    {
        Asus,
        Alienware,
        Microsoft,
        Dell,
        Toshiba,
        HP
    }

    public enum OperatingSystems
    {
        Windows,
        Ubuntu,
        Linux,
        Lubuntu,
        MacOs
    }

}
