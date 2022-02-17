using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class BaseOperations
    {
        //1) Create a application that take 2 numbers and find its sum, product and divide the first by second, also supractthe second from teh first.
        //   Include another method to find the remainder when the first number is divided by second
        static int TakeIntFromConsole(string msg)
        {
            int iNum;
            Console.WriteLine("Please enter the " + msg + " number");
            while (Int32.TryParse(Console.ReadLine(), out iNum) == false)
            {
                Console.WriteLine("Invalid entry. " +
                    "Please try again....");
            }
            return iNum;
        }
        static int AddTwoNumbers(int iNum1, int iNum2)
        {
            var result = iNum1 + iNum2;
            Console.WriteLine($"The sum of {iNum1} and {iNum2} is {result}");
            return result;
        }
        static int MultiplyTwoNumbers(int iNum1, int iNum2)
        {
            var result = iNum1 * iNum2;
            Console.WriteLine($"The product of {iNum1} and {iNum2} is {result}");
            return result;
        }
        static bool CheckNumberIsZero(int number)
        {
            if (number == 0)
            {
                return true;
            }
            return false;
        }
        static int DivideTwoNumbers(int iNum1, int iNum2)
        {
            int result = iNum1 / iNum2;
            Console.WriteLine($"The division result of {iNum1} and {iNum2} is {result}");
            return result;

        }
        static int SubtractTwoNumbers(int iNum1, int iNum2)
        {
            var result = iNum1 - iNum2;
            Console.WriteLine($"The subtraction result of {iNum1} and {iNum2} is {result}");
            return result;
        }
        static int DivisionRemainderTwoNumbers(int iNum1, int iNum2)
        {
            int result = iNum1 % iNum2;
            Console.WriteLine($"The division remainder of {iNum1} and {iNum2} is {result}");
            return result;
        }
        static void OperationsWithTwoNumbers()
        {
            int iNum1, iNum2;
            iNum1 = TakeIntFromConsole("First");
            iNum2 = TakeIntFromConsole("Second");
            int sum = AddTwoNumbers(iNum1, iNum2);
            int product = MultiplyTwoNumbers(iNum1, iNum2);
            if (!CheckNumberIsZero(iNum2))
            {
                int divisionFirstBySecond = DivideTwoNumbers(iNum1, iNum2);
                int remainderOfFirstAndSecond = DivisionRemainderTwoNumbers(iNum1, iNum2);
            }
            else
            {
                Console.WriteLine("Can`t divide by 0!");
            }
            int subtractSecondFromFirst = SubtractTwoNumbers(iNum2, iNum1);

        }


        //2) Create an application that will find the greatest of 3 numbers
        static int GreatestOfThreeNumbers(int iNum1, int iNum2, int iNum3)
        {
            int max_number = iNum1;
            if (iNum2 > max_number) max_number = iNum2;
            else if (iNum3 > max_number) max_number = iNum3;
            Console.WriteLine($"Max number amongst {iNum1},{iNum2} and {iNum3} is {max_number}");
            return max_number;
        }


        //3) create an application that will find the greatest of the given numbers.Take input until the user enters a negative number
        static int GreatestNumber()
        {
            int user_input;
            int max_number = -1;
            do
            {
                user_input = TakeIntFromConsole("");
                if (user_input > max_number) max_number = user_input;
            } while (user_input > -1);
            Console.WriteLine($"Max number is {max_number}");
            return max_number;
        }


        //4) Find the average of all the numbers that are divisible by 7. Take input until the user enters a negative number
        static double AverageOfNumbersDivisibleBy_7()
        {
            int user_input;
            int number_count = 0;
            int sum = 0;
            do
            {
                user_input = TakeIntFromConsole("");
                if (user_input % 7 == 0)
                {
                    number_count++;
                    sum += user_input;
                }
            } while (user_input >= 0);
            double avg_number = sum / number_count;
            Console.WriteLine($"Average number amongst numbers  divisible by 7 is {avg_number}");
            return avg_number;
        }


        //5) Find the length of the given user's name
        static int GetNameLength(string name)
        {
            Console.WriteLine($"the length of the given user's name is {name.Length}");
            return name.Length;
        }


        //6) Create a application that will take username and password from user.check if username is "ABC" and passwords is "123".
        //   Print error message if username or password is wrong
        //   Allow user 3 attempts.
        //   After 3rd attempt if user enters invalid credentials then print msg to intimate user that he/she has exceeded the number of attempts and stop
        static bool UserCheck()
        {
            int attempts_count = 3;
            bool successfull_enter = false;
            while (attempts_count > 0)
            {
                Console.WriteLine($"Attempts left: {attempts_count}");
                attempts_count--;
                Console.WriteLine("Please enter your name:");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter your password:");
                string password = Console.ReadLine();
                if (username != "ABC" || password != "123")
                {
                    Console.WriteLine("Username or password is wrong!!!");
                    continue;
                }
                else
                {
                    successfull_enter = true;
                    Console.WriteLine("Successfully!");
                    break;
                }

            }
            if (successfull_enter == false)
            {
                Console.WriteLine("You have exceeded the number of attempts!");
            }
            return successfull_enter;
        }
        static void taskBaseMethods()
        {

            //1
            //OperationsWithTwoNumbers();

            //2
            //int greatest = GreatestOfThreeNumbers(TakeIntFromConsole("First"), TakeIntFromConsole("Second"), TakeIntFromConsole("Third"));

            //3
            //int greatest = GreatestNumber();

            //4
            //double avg_number = AverageOfNumbersDivisibleBy_7();

            //5
            //Console.WriteLine("Please enter your name:");
            //string name = Console.ReadLine();
            //GetNameLength(name);

            //6
            //UserCheck();
        }
    }
}
