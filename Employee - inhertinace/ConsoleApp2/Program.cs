using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee() { FirstName = "filip", LastName = "kostadinov", Salary = 500, Role = Role.Other };
            SalesPerson salePerson = new SalesPerson("petko", "petkovski");
            Manager manager = new Manager("stanko", "stankovski", 2000);

            employee.PrintInfo();

            salePerson.AddSuccessRevenue(1000);
            salePerson.PrintInfo();

            manager.AddBonus(400);
            manager.PrintInfo();
        }
    }
}
