using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Classes;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime date = DateTime.Now;
            Console.WriteLine(date);

            Console.WriteLine("Buyer info 1. Firstname 2. Lastname 3. Date of birth(day.month.year)");
            Person person = new Person(Console.ReadLine(), Console.ReadLine(), DateTime.Parse(Console.ReadLine()), true);
            Console.WriteLine(person.DateOfBirth);
            Console.WriteLine("Cashier info 1. Firstname 2. Lastname");
            Person cashier = new Person(Console.ReadLine(), Console.ReadLine(), new DateTime(1990, 01, 01), false);

            Cart cart = new Cart();
            Product[] listOfProducts = cart.ListOfProduct;

            var products = new Product[]
            {
                new Product("Milk", 4.2),
                new Product("Eggs", 3.5),
                new Product("Flour", 5.1),
                new Product("Ham", 6),
                new Product("Butter", 7.6),
                new Product("Cheese", 8.9),
                new Product("Tomato", 3.5),
                new Product("Beer", 5) { Declaration = "+18"}
            };



            while (true)
            {
                Console.Clear();
                Console.WriteLine("Products: ");
                foreach (var item in products)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("Do you want anything to buy? input: y/n");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.Write("Enter product: ");
                    string productInput = Console.ReadLine().ToLower();
                    foreach (var item in products)
                    {
                        if (item.Name.ToLower() == productInput)
                        {
                            Array.Resize(ref listOfProducts, listOfProducts.Length + 1);
                            listOfProducts[listOfProducts.Length - 1] = item;
                        }
                    }
                }
                else if (input == "n")
                {
                    cart.ListOfProduct = listOfProducts;
                    break;
                }
                else
                {
                    Console.WriteLine("please input y/n");
                    Console.ReadLine();
                }
            }

            person.Introduce();
            cashier.Introduce();

            if (cart.ListOfProduct.Length == 0)
                Console.WriteLine("You have nothing in the cart, see you next time");

            else
            {
                Console.WriteLine("Your products: ");
                foreach (var item in cart.ListOfProduct)
                {
                    Console.Write(item.Name + ", ");
                }
                Console.WriteLine();

                int personYear = AgeCalculator(person);
                if (ProductValidation(cart.ListOfProduct) && personYear < 18)
                {
                    Console.WriteLine("You need +18 for these products");
                }
                else
                {
                    Console.WriteLine("Please pay the check");
                    double check = Check(cart.ListOfProduct);

                    if (check > 50)
                    {
                        Console.WriteLine("You have discount 10%");
                        check -= check * 0.1;

                        if (person.LoyalCard)
                        {
                            Console.WriteLine("You have discount 15%");
                            check -= check * 0.15;
                        }
                    }
                    else
                    {
                        if (person.LoyalCard)
                        {
                            Console.WriteLine("You have discount 15%");
                            check -= check * 0.15;
                        }
                    }
                    Console.WriteLine($"The check is {check} $");
                }                
            }
        }

        public static double Check(Product[] products)
        {
            double result = 0;
            foreach (var item in products)
            {
                result += item.Price;
            }
            return result;
        }

        public static int AgeCalculator(Person person)
        {
            DateTime dateNow = DateTime.Now;
            int age = dateNow.Year - person.DateOfBirth.Year;

            if (dateNow.Month < person.DateOfBirth.Month)
                age--;

            if (dateNow.Month == person.DateOfBirth.Month && dateNow.Day < person.DateOfBirth.Day)
                age--;

            return age;
        } 

        public static bool ProductValidation(Product[] products)
        {
            foreach (var item in products)
            {
                if (item.Declaration == "+18")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
