using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

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
                                Console.Clear();
                                Console.WriteLine(" _______________________________________________________________________ ");
                                Console.WriteLine("|                                                                       |");
                                Console.WriteLine("| 1. Add an user to the existing user database.                         |");
                                Console.WriteLine("| 2. Delete an user by entering his ID.                                 |");
                                Console.WriteLine("|        [Optionally enter any value to exit to main menu]              |");
                                Console.WriteLine("|_______________________________________________________________________|");
                                int.TryParse(Console.ReadLine(), out choiceForSubMenu);
                                switch (choiceForSubMenu)
                                {
                                    case 1:
                                    {
                                        userList.Add(new User().AddUser());
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.WriteLine("Enter value of ID of user you wish to delete.");
                                        var idInputed = int.Parse(Console.ReadLine());
                                        foreach (var user in userList)
                                        {
                                            if (user.IdUser == idInputed)
                                            {
                                                Console.WriteLine("Are you sure you want to delete:");
                                                user.PrintUserInfo();
                                                Console.WriteLine("Delete: y[es]/n[o]");
                                                if(Console.ReadKey().Key == ConsoleKey.Y)
                                                    userList.Remove(user);
                                                break;
                                            }
                                        }
                                        Console.WriteLine("User not found.");
                                        break;
                                    }
                                    default:
                                    {
                                        choiceForSubMenu = 0;
                                        Console.WriteLine("Exiting sub-menu.");
                                        break;
                                    }
                                }
                            }while (choiceForSubMenu == 0) ;
                            break;
                        }
                        case 2:
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine(
                                    " _______________________________________________________________________ ");
                                Console.WriteLine(
                                    "|                                                                       |");
                                Console.WriteLine(
                                    "| 1. Add an mobilephone to the existing mobilephone database.           |");
                                Console.WriteLine(
                                    "| 2. Delete an mobilephone by entering Guid.                            |");
                                Console.WriteLine(
                                    "|        [Optionally enter any value to exit to main menu]              |");
                                Console.WriteLine(
                                    "|_______________________________________________________________________|");
                                int.TryParse(Console.ReadLine(), out choiceForSubMenu);
                                switch (choiceForSubMenu)
                                {
                                    case 1:
                                    {
                                        mobileList.Add(new MobilephoneTechnologyItem().AddPhone(userList));
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.WriteLine("Enter value of Guid [or unique start of guid] of mobilephone you wish to delete.");
                                        var idInputed = Console.ReadLine();
                                        foreach (var phone in mobileList)
                                        {
                                            if (phone.IsGuid(idInputed))
                                            {
                                                Console.WriteLine("Are you sure you want to delete:");
                                                phone.PrintMobilephoneInfo();
                                                Console.WriteLine("Delete: y[es]/n[o]");
                                                if (Console.ReadKey().Key == ConsoleKey.Y)
                                                    mobileList.Remove(phone);
                                                break;
                                            }
                                        }

                                        Console.WriteLine("Phone not found.");
                                        break;
                                    }
                                    default:
                                    {
                                        choiceForSubMenu = 0;
                                        break;
                                    }
                                }
                            } while (choiceForSubMenu == 0);
                            break;
                        }
                        case 3:
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine(" _______________________________________________________________________ ");
                                Console.WriteLine("|                                                                       |");
                                Console.WriteLine("| 1. Add an computer to the existing computer database.                 |");
                                Console.WriteLine("| 2. Delete an computer by entering Guid.                               |");
                                Console.WriteLine("|        [Optionally enter any value to exit to main menu]              |");
                                Console.WriteLine("|_______________________________________________________________________|");
                                int.TryParse(Console.ReadLine(), out choiceForSubMenu);
                                switch (choiceForSubMenu)
                                {
                                    case 1:
                                    {
                                        computerList.Add(new ComputerTechnologyItem().AddComputer());
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.WriteLine("Enter value of Guid [or unique start of guid] of computer you wish to delete.");
                                        var idInputed = Console.ReadLine();
                                        foreach (var computer in computerList)
                                        {
                                            if (computer.IsGuid(idInputed))
                                            {
                                                Console.WriteLine("Are you sure you want to delete:");
                                                computer.PrintComputerInfo();
                                                Console.WriteLine("Delete: y[es]/n[o]");
                                                if (Console.ReadKey().Key == ConsoleKey.Y)
                                                    computerList.Remove(computer);
                                                break;
                                            }
                                        }

                                        Console.WriteLine("Computer not found.");
                                                break;
                                    }
                                    default:
                                    {
                                        choiceForSubMenu = 0;
                                        break;
                                    }
                                }
                            } while (choiceForSubMenu == 0);
                            break;
                        }
                        case 4:
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine(
                                    " _______________________________________________________________________ ");
                                Console.WriteLine(
                                    "|                                                                       |");
                                Console.WriteLine(
                                    "| 1. Add an vehicle to the existing vehicle database.                   |");
                                Console.WriteLine(
                                    "| 2. Delete an vehicle by entering Guid.                                |");
                                Console.WriteLine(
                                    "|        [Optionally enter any value to exit to main menu]              |");
                                Console.WriteLine(
                                    "|_______________________________________________________________________|");
                                int.TryParse(Console.ReadLine(), out choiceForSubMenu);
                                switch (choiceForSubMenu)
                                {
                                    case 1:
                                    {
                                        vehicleList.Add(new VehicleItem().AddVehicle(userList));
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.WriteLine("Enter value of Guid [or unique start of guid] of vehicle you wish to delete.");
                                        var idInputed = Console.ReadLine();
                                        foreach (var vehicle in vehicleList)
                                        {
                                            if (vehicle.IsGuid(idInputed))
                                            {
                                                Console.WriteLine("Are you sure you want to delete:");
                                                vehicle.PrintVehicleInfo();
                                                Console.WriteLine("Delete: y[es]/n[o]");
                                                if (Console.ReadKey().Key == ConsoleKey.Y)
                                                    vehicleList.Remove(vehicle);
                                                break;
                                            }
                                        }
                                        Console.WriteLine("Computer not found.");
                                        break;
                                    }
                                    default:
                                    {
                                        choiceForSubMenu = 0;
                                        break;
                                    }
                                }
                            } while (choiceForSubMenu == 0);
                                    break;
                        }
                        case 5:
                        {
                            PrintUserList(userList);
                            Console.WriteLine("Press any button to return to main menu.");
                            Console.ReadKey();
                            break;
                        }
                        case 6:
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine(" __________________________________________________________________ ");
                                Console.WriteLine("|                                                                  |");
                                Console.WriteLine("| 1.Print all mobile inventory                                     |");
                                Console.WriteLine("| 2.Print depending on serial entered                              |");
                                Console.WriteLine("| 3.Print all phones by entered manufacturer                       |");
                                Console.WriteLine("| 4.Print users who's phones warranty is expiring in year entered  |");
                                Console.WriteLine("| 5.Current estimated value of phone. [Enter serial]               |");
                                Console.WriteLine("|   [Optionally enter any value to return to main menu]            |");
                                Console.WriteLine("|__________________________________________________________________|");
                                int.TryParse(Console.ReadLine(), out choiceForSubMenu);
                                    switch (choiceForSubMenu)
                                {
                                    case 1:
                                    {
                                        Console.Clear();
                                        PrintMobilephoneList(mobileList);
                                        Console.WriteLine("Press any button to return to sub menu.");
                                        Console.ReadKey();
                                        break;
                                    }
                                    case 2:
                                    {
                                        var printedSomething = 0;
                                        Console.WriteLine("Please enter part or whole guid:");
                                        var enteredSerialNumber = Console.ReadLine();
                                        Console.Clear();
                                        foreach (var phone in mobileList)
                                        {
                                            if (phone.IsGuid(enteredSerialNumber))
                                            {
                                                phone.PrintMobilephoneInfo();
                                                printedSomething++;
                                            }
                                        }                                        
                                        if(printedSomething == 0)
                                            Console.Write("Phone not found. ");                                            
                                        Console.WriteLine("Press any button to return to sub menu.");
                                        Console.ReadKey();
                                                break;
                                    }
                                    case 3:
                                    {
                                        var printedSomething = 0;
                                        Console.WriteLine("Please enter manufacturer:");
                                        var manufacturerString = Console.ReadLine();
                                        Console.Clear();
                                        foreach (var phone in mobileList)
                                        {
                                            if (phone.IsManufacturer(manufacturerString))
                                            {
                                                printedSomething++;
                                                phone.PrintMobilephoneInfo();
                                            }
                                        }
                                        if (printedSomething == 0)
                                            Console.Write("Phone not found. ");
                                        Console.WriteLine("Press any button to return to sub menu.");
                                        Console.ReadKey();
                                        break;
                                    }
                                    case 4:
                                    {
                                        Console.WriteLine("Enter year you're interested in:");
                                        var yearEntered = int.Parse(Console.ReadLine());
                                        Console.Clear();
                                        foreach (var phone in mobileList)
                                        {
                                            if (phone.IsWarrantyEndYear(yearEntered))
                                            {
                                                phone.MobilephoneUser.PrintUserInfo();
                                                Console.WriteLine();
                                            }
                                        }
                                        Console.WriteLine("Press any button to return to sub menu.");
                                        Console.ReadKey();
                                        break;
                                    }
                                    case 5:
                                    {
                                        var printedSomething = 0;
                                        Console.WriteLine("Please enter part or whole guid:");
                                        var enteredSerialNumber = Console.ReadLine();
                                        Console.Clear();
                                        foreach (var phone in mobileList)
                                        {
                                            if (phone.IsGuid(enteredSerialNumber))
                                            {
                                                Console.WriteLine("Estimated value is: " + phone.GetRealValue());
                                                phone.PrintMobilephoneInfo();
                                                printedSomething++;
                                            }
                                        }
                                        if (printedSomething == 0)
                                            Console.Write("Phone not found. ");
                                        Console.WriteLine("Press any button to return to sub menu.");
                                        Console.ReadKey();
                                                break;
                                    }
                                    default:
                                    {
                                        choiceForSubMenu = 99;
                                        break;
                                    }
                                }
                                
                                } while (choiceForSubMenu != 99);
                            break;
                        }
                        case 7:
                        {
                            PrintComputerList(computerList);
                            Console.WriteLine("Press any button to return to main menu.");
                            Console.ReadKey();
                            break;
                        }
                        case 8:
                        {
                            PrintVehicleList(vehicleList);
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
            Console.WriteLine("| 7. Run requests computer inventory data                   |");
            Console.WriteLine("| 8. Run requests on vehicle inventory data                 |");
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
