using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Classes
{
    public class Product
    {        
        public string Name { get; set; }
        public double Price { get; set; }
        public int SerialNumber { get; set; }
        public string Description { get; set; }
        public string Declaration { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
            SerialNumber = new Random().Next(10000, 99999);
        }
    }
}
