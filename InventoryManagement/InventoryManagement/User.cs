using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class User
    {
        private static int InstanceIterator { get; set; }
        public int IdUser { get; }
        public string NameOfUser { get; set; }
        public string SurnameOfUser { get; set; }

        public User()
        {
            InstanceIterator++;
            IdUser = InstanceIterator;
            NameOfUser = " ";
            SurnameOfUser = " ";
        }
        public User(string nameOfUser, string surnameOfUser)
        {
            InstanceIterator++;
            IdUser = InstanceIterator;
            NameOfUser = nameOfUser;
            SurnameOfUser = surnameOfUser;
        }

        public void PrintUserInfo()
        {
            Console.WriteLine(" _________________________________ ");
            Console.WriteLine("                                 ");
            Console.WriteLine($" User ID: {IdUser}");
            Console.WriteLine($" User name: {NameOfUser}");
            Console.WriteLine($" User surname: {SurnameOfUser}");
            Console.WriteLine("_________________________________");
            Console.WriteLine();
        }

        public User[] FillWithDummyUsers()
        {
            var userArray = new User[10];
            for (var userIterator = 0; userIterator < userArray.Length; userIterator++)
            {
                userArray[userIterator] = new User(("UserName"+userIterator), ("UserSurname" +userIterator ));
            }

            return userArray;
        }

        public User AddUser()
        {
            var userForStaging = new User();
            Console.WriteLine("Please enter name of user:");
            userForStaging.NameOfUser = FormatStringInput(Console.ReadLine());
            Console.WriteLine("Please enter user surname:");
            userForStaging.SurnameOfUser = FormatStringInput(Console.ReadLine());
            return userForStaging;
        }
        private static string FormatStringInput(string argStringPassed)
        {
            if (argStringPassed.Contains(' '))
                argStringPassed.Trim(' ');
            if (!char.IsLower(argStringPassed[0]))
                return argStringPassed;
            var tmpString = new StringBuilder(argStringPassed);
            tmpString[0] = char.ToUpper(tmpString[0]);
            argStringPassed = tmpString.ToString();
            return argStringPassed;
        }
    }
}
