using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class SalesPerson : Employee
    {
        private double SuccessSaleRevenue { get; set; }

        public SalesPerson(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = 500;
            Role = Role.Sales;
        }

        public void AddSuccessRevenue(double value)
        {
            SuccessSaleRevenue += value;
        }

        public override double GetSalary()
        {
            if (SuccessSaleRevenue >= 500 && SuccessSaleRevenue < 2000)
            {
                return Salary + 500;
            }
            else if (SuccessSaleRevenue >= 2000 && SuccessSaleRevenue < 5000)
            {
                return Salary + 800;
            }
            else if (SuccessSaleRevenue >= 5000)
            {
                return Salary + 2000;
            }
            else
            {
                return Salary;
            }
        }
    }
}
