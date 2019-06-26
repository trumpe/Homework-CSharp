using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Trainer : User
    {
        public Trainer(string username, string password)
        {
            Username = username;
            Password = password;
            Role = Role.Trainer;
        }
    }
}
