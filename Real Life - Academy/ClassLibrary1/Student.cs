using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Student : User
    {
        public Subject CurrentSubject { get; set; }
        public Dictionary<Subject, int> Grades { get; set; }

        public Student(string username, string password)
        {
            Username = username;
            Password = password;
            Role = Role.Student;
        }
    }
}
