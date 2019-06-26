using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Admin : User
    {
        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
            Role = Role.Admin;
        }
    }
}
