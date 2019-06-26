using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Manager : Employee
    {
        private double Bonus { get; set; }

        public Manager(string firstName, string lastName, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Role = Role.Manager;
        }

        public void AddBonus(double bonus)
        {
            Bonus = bonus;
        }
        public override double GetSalary()
        {
            return Salary + Bonus;
        }
    }
}
