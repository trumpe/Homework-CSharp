using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the operation: ");
            string operation = Console.ReadLine();

            if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
            {
                Console.WriteLine("Invalid operation selected, please try again.");
            }
            else
            {
                Console.WriteLine("Enter the first number: ");
                int number1;
                bool isNumber1 = int.TryParse(Console.ReadLine(), out number1);

                Console.WriteLine("Enter the second number: ");
                int number2;
                bool isNumber2 = int.TryParse(Console.ReadLine(), out number2);

                if (isNumber1 && isNumber2)
                {
                    double result = 0;

                    switch (operation)
                    {
                        case "+":
                            result = number1 + number2;
                            break;
                        case "-":
                            result = number1 - number2;
                            break;
                        case "*":
                            result = number1 * number2;
                            break;
                        case "/":
                            result = number1 / Convert.ToDouble(number2);
                            break;
                    }
                    Console.WriteLine("The result is: " + result);
                }
                else
                {
                    Console.WriteLine("Invalid input numbers, please try again.");
                }
            }
            Console.ReadLine();
        }
    }
}
