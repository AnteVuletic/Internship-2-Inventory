using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class User
    {
        public string NameOfUser { get; set; }
        public string SurnameOfUser { get; set; }

        public User()
        {
            NameOfUser = "";
            SurnameOfUser = "";
        }
    }
}
