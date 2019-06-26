using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Classes
{
    public class Cart
    {
        public int SerialNumber { get; set; }
        public Product[] ListOfProduct { get; set; }

        public Cart()
        {
            ListOfProduct = new Product[0];
        }
    }
}
