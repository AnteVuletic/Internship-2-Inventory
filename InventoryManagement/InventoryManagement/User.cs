using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class User
    {
        public static int IdUser { get; private set; }
        public string NameOfUser { get; set; }
        public string SurnameOfUser { get; set; }

        public User()
        {
            IdUser++;
            NameOfUser = " ";
            SurnameOfUser = " ";
        }
        public User(string nameOfUser, string surnameOfUser)
        {
            IdUser++;
            NameOfUser = nameOfUser;
            SurnameOfUser = surnameOfUser;
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
    }
}
