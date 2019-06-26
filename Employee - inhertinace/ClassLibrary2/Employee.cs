using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Employee
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public double Salary { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"{FirstName} {LastName} - {GetSalary()} - {Role}");
        }

        public virtual double GetSalary()
        {
            return Salary;
        }
    }
}
