using Calculator;
using System;
using System.Diagnostics;
using UnderstandingExceptionApp;

namespace UnderstandingExceptionApp
{
    class Program
    {
        void MyDivide()
        {
            try
            {
                Calc c = new Calc();
                double res = c.Divide();
                Console.WriteLine($"The result is {res}");
            }
            catch (InValidNumberException ivne)
            {
                Debug.WriteLine(ivne.Message + " " + DateTime.Now.ToLongDateString());
                Debug.WriteLine(ivne.StackTrace);
                Debug.WriteLine("-------------------");
                Console.WriteLine("Numerator cannot be negative");
            }
            catch (DivideByZeroException dbz)
            {
                //Console.WriteLine(dbz.Message);
                //Console.WriteLine(dbz.StackTrace);
                Debug.WriteLine(dbz.Message + " " + DateTime.Now.ToLongDateString());
                Debug.WriteLine(dbz.StackTrace);
                Debug.WriteLine("-------------------");
                Console.WriteLine("Denominator cannot be zero");
            }

            catch (FormatException fe)
            {
                Debug.WriteLine(fe.Message + " " + DateTime.Now.ToLongDateString());
                Debug.WriteLine(fe.StackTrace);
                Debug.WriteLine("-------------------");
                //Console.WriteLine(fe.Message);
                Console.WriteLine("Invalid entry for number");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("oops something went wrong!!!!");
            }
            finally
            {
                Console.WriteLine("Will execute always");
            }

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.MyDivide();
            Console.ReadKey();
        }
    }
    public class InValidNumberException : Exception
        {
            string message;
            public InValidNumberException()
            {
                message = "Invalid entry for number. Number cannot be negative";
            }
            public InValidNumberException(int num)
            {
                message = "Invalid entry for number. Number cannot be negative " + num;
            }
            public InValidNumberException(int num, string msg)
            {
                message = msg + " " + num;
            }
            public override string Message => message;
        }
    
}

namespace Calculator
{
     public class Calc
     {
        public double Divide()
            {
                int num1, num2;
                double result = 0;
                Console.WriteLine("Please enter the first number");
                num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the second number");
                num2 = Convert.ToInt32(Console.ReadLine());
                if (num1 < 0)
                    throw new InValidNumberException(num1, "Negative numebr not allowed");
                result = num1 / num2;
                return result;

            }
     }
}

