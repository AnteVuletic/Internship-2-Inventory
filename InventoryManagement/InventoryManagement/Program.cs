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
            var userList = new List<User>();
            var vehicleList = new List<VehicleItem>();
            var mobileList = new List<MobilephoneTechnologyItem>();
            var computerList = new List<ComputerTechnologyItem>();
            var choiceForMenu = 0;
            do
            {
                DisplayMenuOptions();
                Console.WriteLine("Your choice if you choose to accept it:");
                var inputTesting = int.TryParse(Console.ReadLine(), out choiceForMenu);
                if (!inputTesting)
                {
                    Console.WriteLine("Input is not an number please try again.");
                    choiceForMenu = 0;
                }
                else
                {
                    var choiceForSubMenu = 0;
                    switch (choiceForMenu)
                    {
                        case 1:
                        { 
                            do {
                                if (!(int.TryParse(Console.ReadLine(), out choiceForSubMenu)))
                                {
                                    Console.Clear();
                                    Console.WriteLine(" _______________________________________________________________________ ");
                                    Console.WriteLine("|                                                                       |");
                                    Console.WriteLine("| 1. Add an user to the existing user database.                         |");
                                    Console.WriteLine("| 2. Delete an user by entering his guid ( or unique part of his guid): |");
                                    Console.WriteLine("|        [Optionally enter any value to exit to main menu]              |");
                                    Console.WriteLine("|_______________________________________________________________________|");
                                        switch (choiceForSubMenu)
                                        {
                                            case 1:
                                            {
                                                userList.Add(new User().AddUser());
                                                break;
                                            }
                                            default:
                                            {
                                                choiceForSubMenu = 0;
                                                Console.WriteLine("Exiting sub-menu.");
                                                break;
                                            }
                                        }
                                }
                            }while (choiceForSubMenu == 0) ;
                            break;
                        }
                        case 5:
                        {
                            PrintUserList(userList);
                            Console.WriteLine("Press any button to return to main menu.");
                            Console.ReadKey();
                            break;
                        }
                        case 9:
                        {
                            userList= new List<User>(new User().FillWithDummyUsers());
                            vehicleList = new List<VehicleItem>(new VehicleItem().FillVehiclesWithDummyValues(userList));
                            mobileList = new List<MobilephoneTechnologyItem>(new MobilephoneTechnologyItem().FillMobilesphonesWithDummyItems(userList));
                            computerList = new List<ComputerTechnologyItem>(new ComputerTechnologyItem().FillComputerTechnologyWithDummyItems());
                            PrintUserList(userList);
                            Console.WriteLine("Press any button to view vehicle list.");
                            Console.ReadKey();
                            Console.Clear();
                            PrintVehicleList(vehicleList);
                            Console.WriteLine("Press any button to view mobile list.");
                            Console.ReadKey();
                            Console.Clear();
                            PrintMobilephoneList(mobileList);
                            Console.WriteLine("Press any button to view computer list.");
                            Console.ReadKey();
                            Console.Clear();
                            PrintComputerList(computerList);
                            Console.WriteLine("Press any key to return to main menu");
                            Console.ReadKey();
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Execution stopping.");
                            choiceForMenu = 99;
                            break;
                        }
                    }
                }

            } while (choiceForMenu != 99);

        }
        private static void DisplayMenuOptions()
        {
            Console.Clear();
            Console.WriteLine(" ___________________________________________________________ ");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("| 1. Add or remove user data                                |");
            Console.WriteLine("| 2. Add or remove  mobilephone inventory data              |");
            Console.WriteLine("| 3. Add or remove  computer inventory data                 |");
            Console.WriteLine("| 4. Add or remove vehicle inventory data                   |");
            Console.WriteLine("| 5. Print all users                                        |");
            Console.WriteLine("| 6. Run requests on mobile inventory data                  |");
            Console.WriteLine("| 7. Run requests on vehicle inventory data                 |");
            Console.WriteLine("| 8. Run requests computer inventory data                   |");
            Console.WriteLine("| 9. Press this to generate random data for every inventory |");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("|      Any number choice not within the given number        |");
            Console.WriteLine("|                options stops execution                    |");
            Console.WriteLine("|___________________________________________________________|");
        }

        private static void PrintUserList(List<User> argUserListPassed)
        {
            foreach (var user in argUserListPassed )
                user.PrintUserInfo();
        }

        private static void PrintVehicleList(List<VehicleItem> argVehicleListPassed)
        {
            foreach (var vehicle in argVehicleListPassed)
            {
                vehicle.PrintVehicleInfo();
            }
        }

        private static void PrintMobilephoneList(List<MobilephoneTechnologyItem> argMobilephoneListPassed)
        {
            foreach (var phone in argMobilephoneListPassed)
            {
                phone.PrintMobilephoneInfo();
            }
        }

        private static void PrintComputerList(List<ComputerTechnologyItem> argComputerListPassed)
        {
            foreach (var computerTechnologyItem in argComputerListPassed)
            {
                computerTechnologyItem.PrintComputerInfo();
            }
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
        Huawei,
        Sony
    }

    public enum ComputerManufacturer
    {
        Asus,
        Alienware,
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
