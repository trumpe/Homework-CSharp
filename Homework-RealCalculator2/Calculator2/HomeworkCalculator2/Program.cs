using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCalculator2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[0];
            int a = 0;
            bool temp = true;
            while (temp)
            {
                Console.WriteLine("Enter the operation: ");
                string operation = Console.ReadLine();
                if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
                {
                    Console.WriteLine("Input numbers: ");
                    int firstNum;
                    int secondNum;
                    bool isFirstNum = int.TryParse(Console.ReadLine(), out firstNum);
                    bool isSecondNum = int.TryParse(Console.ReadLine(), out secondNum);

                    if (isFirstNum && isSecondNum)
                    {
                        double result = 0;
                        switch (operation)
                        {
                            case "+":
                                result = firstNum + secondNum;
                                break;
                            case "-":
                                result = firstNum - secondNum;
                                break;
                            case "*":
                                result = firstNum * secondNum;
                                break;
                            case "/":
                                result = firstNum / Convert.ToDouble(secondNum);
                                break;
                        }
                        if (secondNum == 0 && operation == "/")
                            Console.WriteLine("you can not divide with zero");
                        else
                        {
                            Console.WriteLine("result is: " + result);
                            Array.Resize(ref arr, arr.Length + 1);
                            arr[a] = Convert.ToString(firstNum) + operation + Convert.ToString(secondNum) + "=" + result;
                            a++;
                        }
                        while (true)
                        {
                            Console.WriteLine("Do you want another calculation? enter Y/N");
                            string anotherCalc = Console.ReadLine();
                            if (anotherCalc.ToLower() == "n")
                            {
                                Console.WriteLine("Calculation history");
                                foreach (var item in arr)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.ReadLine();
                                temp = false;
                                break;
                            }
                            else if (anotherCalc.ToLower() == "y")
                            {
                                break;
                            }
                        }
                    }
                    else
                        Console.WriteLine("you entered invalid numbers, please try again");
                }
                else
                    Console.WriteLine("You entered unvalid operation! Please try again");
            }
        }
    }
}
