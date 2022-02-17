using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class UnderstandingArray
    {
        //1) Take a range from user(min and max value) and find all teh prime numbers in that range
        public bool CheckNumberIsPrime(int number)
        {
            bool isPrime = true;
            if (number > 1)
            {
                for(int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }
            else
            {
                isPrime = false;
            }
            return isPrime;
        }
        public void PrimeNumbersInRange()
        {
            int min_number, max_number;
            Console.WriteLine("Enter min value of a range: ");
            Int32.TryParse(Console.ReadLine(), out min_number);
            Console.WriteLine("Enter max value of a range: ");
            Int32.TryParse(Console.ReadLine(), out max_number);

            int[] range = new int[max_number - min_number + 1];
            range[0] = min_number;
            Console.WriteLine(0 + " element:" + range[0]);
            for (int i = 1; i < max_number - min_number + 1; i++)
            {
                range[i] = range[i - 1] + 1;
                Console.WriteLine(i + " element:" + range[i]);
            }
            Console.WriteLine("Prime numbers: ");
            for (int i = 0; i < range.Length; i++)
            {
                if (CheckNumberIsPrime(range[i]))
                    Console.WriteLine(range[i] + " is prime");
            }
        }

        //2) Validate a Card number
        //4477 4683 4311 3002
        //2003 1134 3864 7744- Reverse the number
        //2+0*2+0+3*2+1+1*2+3+4*2+3+8*2+6+4*2+7+7*2+4+4*2 - identify the even position numbers and multiply by 2
        //2+0+0+6+1+2+3+8+3+16+6+8+7+14+4+8 - Multiplied
        //2+0+0+6+1+2+3+8+3+(1+6)+6+8+7+(1+4)+4+8 - If results in 2 digit number sum them up
        //2+0+0+6+1+2+3+8+3+7+6+8+7+5+4+8 - Sum up all teh values
        //70%10-> Divide by 10 if 0 remainder then valid card number
        public int[] Reverse(int[] number)
        {
            int[] reversed_number = new int[number.Length];
            
            for(int i=number.Length-1; i>=0; i--)
            {
                reversed_number[number.Length - i - 1] = number[i];
            }
            foreach(var digit in reversed_number)
            {
                Console.Write(digit);
            }
            Console.WriteLine();
            return reversed_number;
        }
        public int[] EvenPositionsAndMultiplyBy2(int[] number)
        {
            int[] changed_number = new int[number.Length];
            for(int i=0; i < number.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    int square= number[i] * number[i];
                    if (square > 9)
                    {
                        int first= square / 10;
                        int last = square % 10;
                        changed_number[i] = first + last;
                        continue;
                    }
                    
                        changed_number[i] = square;                   
                    
                }
                else
                {
                    changed_number[i] = number[i];
                }
            }
            foreach (var digit in changed_number)
            {
                Console.Write(digit);
            }
            return changed_number;
        }
        public bool SumAndDivide(int[] number)
        {
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                sum += number[i];
            }
            int remainder = sum % 10;
            if (remainder == 0)
            {
                Console.WriteLine("\nCard is valid");
                return true;
            }
            else 
            {
                Console.WriteLine("\nCard is not valid");
                return false; 
            }
        }
        public void ValidateCardNumber()
        {
            int len = 16;
            int[] card_number = new int[len];
            Console.WriteLine("Enter card number(16 digits):");
            string card_string = Console.ReadLine();
            int last_index = 0;
            for (int h = 0; h < card_string.Length; h++)
            {
                if (card_string[h] == ' ') continue;
                Int32.TryParse(card_string[h].ToString(), out card_number[last_index]);
                last_index++;
            }
            int[] reversed_number = Reverse(card_number);
            int[] even_positions_changed = EvenPositionsAndMultiplyBy2(reversed_number);
            bool valid_card = SumAndDivide(even_positions_changed);


        }        

        //3) Take 11 numbers from user and identify the maximum repeating number(mode). If no number repeats print -1
        public bool NumberIsInArray(int [,] arr,int number)
        {
            for(int i=0; i < arr.Length/2; i++)
            { 
            
                if (arr[0,i] == number) return true;
            }
            return false;
        }
        public void MaximumRepeatingNumber()
        {
            int[] numbers = new int[11];
            Console.WriteLine("You should enter 11 numbers.");
            for(int h = 0; h < 11; h++)
            {
                Console.WriteLine("Enter"+ h +" value: ");
                Int32.TryParse(Console.ReadLine(), out numbers[h]);
            }
            int i = 0;
            int[,] repetitions = new int[2,11];
            int last_index = 0;
            for(int j = 0; j < 11; j++)
            {
                int num_count = 0;
                if (!NumberIsInArray(repetitions, numbers[j]))
                {
                    for (int k = 0; k < 11; k++)
                    {
                        if (numbers[j] == numbers[k]) num_count++;
                    }
                    repetitions[0,last_index] = numbers[j];
                    repetitions[1,last_index] = num_count;
                    last_index++;
                }
            }
            int max_count_repetitions = repetitions[1,0];
            for (int j=1; j < 11; j++)
            {
                if (repetitions[1,j] > max_count_repetitions) max_count_repetitions = repetitions[1,j];
            }
            if (max_count_repetitions > 1)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (repetitions[1,j] == max_count_repetitions)
                    {
                        Console.WriteLine("Number " + repetitions[0,j] + " has "+ max_count_repetitions+" repetitions ");
                    }
                }
            }
            else
            {
                Console.WriteLine("No repetitions, -1");
            }
            
            
        }

        //4) Take 10 numbers from user and identfy if a number and its square are present.If yes then print the number
        public void NumberAndSquareExists()
        {
            int len = 10;
            int[] numbers = new int[len];
            Console.WriteLine("You should enter "+len+" numbers.");
            for (int h = 0; h < len; h++)
            {
                Console.WriteLine("Enter" + h + " value: ");
                Int32.TryParse(Console.ReadLine(), out numbers[h]);
            }

            for(int i=0; i < len; i++)
            {
                int square = numbers[i] * numbers[i];
                for (int j = 0; j < len; j++)
                {
                    if (numbers[j] == square)
                    {
                        Console.WriteLine("Number = "+numbers[i]+"  Square = "+square);
                        break;
                    }
                }
            }
        }
    }
}
