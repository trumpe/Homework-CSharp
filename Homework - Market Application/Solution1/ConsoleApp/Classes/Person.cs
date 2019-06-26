using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Classes
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SSN { get; set; }
        public bool LoyalCard { get; set; }

        public Person(string firstName, string lastName, DateTime dateOfBirth, bool loyalCard)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            SSN = new Random().Next(1000, 9999);
            LoyalCard = loyalCard;
        }

        public void Introduce()
        {
            Console.WriteLine($"hi my name is {FirstName}");
        }
    }

}
