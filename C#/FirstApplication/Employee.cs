using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    //1) Create a application taht will take employee data
    //Id, Name, age, phone, skills
    //Emplyee can add 5 skills at maximum
    //Take employee details and print the details

    //2) Use the class you created in question 1
    //Add a method that will take a skill and check if the employee has it(Use indexer)
    //Take a number and print the skill of employee in the list(Ensure you take number and its inbetween 0-4)
    class Employee
    {
        int id, age;
        public int Id { get { return id; } set { id = value; } }
        public string Name { get; set; }
        public int Age { get { return age; } set { age = value; } }
        public string Phone { get; set; }

        string[] Skills = new string[5];
        public string this[int index]
        {
            get {
                return Skills[index];
            }
            set { Skills[index] = value; }
        }
        public bool this[string skill]
        {
            get {
                foreach (var sk in Skills)
                {
                    if (sk != null && sk.ToLower() == skill.ToLower()) return true;
                }
                return false;
            }
        }
        public Employee()
        {
            Id = 0;
            Name = "Unknown";
            Age = 0;
            Phone = "";
        }

        public Employee(int id, string name, int age, string phone)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
        }

        public void PrintEmployeeDetails()
        {
            Console.WriteLine("=========================Employee Details=========================");
            Console.WriteLine("Employee Id: " + Id);
            Console.WriteLine("Employee Name: " + Name);
            Console.WriteLine("Employee Age: " + Age);
            Console.WriteLine("Employee Phone: " + Phone);
            Console.WriteLine("Skills: ");
            foreach (var skill in Skills)
            {
                Console.WriteLine(skill);
            }
        }

        public void SetEmployeeDetails()
        {
            Console.WriteLine("=========================Enter start=========================");
            Console.WriteLine("Please enter Employee Id(integer): ");
            while (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry for id. Try again");

            }
            Id = id;
            Console.WriteLine("Please enter Employee Name:");
            Name = Console.ReadLine();
            do
            {
                Console.WriteLine("Please enter Employee Age(>0): ");
                Int32.TryParse(Console.ReadLine(), out age);

            } while (age <= 0);
            Age = age;
            Console.WriteLine("Please enter Employee Phone:");
            Phone = Console.ReadLine();
            string choice = "no";
            int cnt = 0;
            do
            {
                Console.WriteLine($"Please enter {(cnt + 1)} skill (maximum {Skills.Length})  ");
                Skills[cnt] = Console.ReadLine();
                Console.WriteLine("Do you want to add another skill? Enter no to exit");
                choice = Console.ReadLine().ToLower();
                cnt++;
            } while (choice != "no" && cnt <= Skills.Length);
            Console.WriteLine("=========================Enter end=========================");

        }

        //Add a method that will take a skill and check if the employee has it(Use indexer)
        public void CheckHasSkill()
        {
            string choice = "yes";
            do
            {
                Console.WriteLine("Please enter skill to check if the employee has it:");
                string skill = Console.ReadLine();
                bool hasSkill = this[skill];//indexer usage
                if (hasSkill)
                {
                    Console.WriteLine("Employee has skill: " + skill);
                }
                else
                {
                    Console.WriteLine("Employee doesn`t have skill: " + skill);
                }
                Console.WriteLine("Do you want to check one more skill?(print no to exit)");
                choice = Console.ReadLine();
            } while (choice != "no");
        }

        //Take a number and print the skill of employee in the list(Ensure you take number and its inbetween 0-4)
        public void ShowSkillByIndex()
        {
            string choice = "yes";
            do
            {
                int skill_ind = -1;
                do
                {
                    Console.WriteLine("Please enter skill index(between 0 and 4):");
                    Int32.TryParse(Console.ReadLine(), out skill_ind);
                } while (skill_ind < 0 || skill_ind > 4);
                string skill = this[skill_ind]; //indexer usage
                if (skill != "")
                {
                    Console.WriteLine($"Employee {skill_ind} skill: " + skill);
                }
                else
                {
                    Console.WriteLine($"Employee doesn`t have skill at {skill_ind}");
                }
                Console.WriteLine("Do you want to find one more skill?(print no to exit)");
                choice = Console.ReadLine();
            } while (choice != "no");
        }
    }


    //3) Create an application taht will take 5 employees data and print the data
    //Take a skill name and print all teh employee who have the skill

    class Company
    {
        Employee[] employees = new Employee[3];
        public Employee[] this[string skill]
        {
            get {
                Employee[] employeesWithSkill = new Employee[5];
                int last = 0;
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i][skill])
                    {
                        employeesWithSkill[last] = employees[i];
                        last++;
                    }
                }
                return employeesWithSkill;
            }
            set { /* set the specified index to value here */ }
        }
        public Company()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = new Employee();

            }
        }
        //take 5 employees data 
        public void SetEmployeesData(int employee_amount)
        {
            for (int i = 0; i < employee_amount; i++)
            {
                Console.WriteLine($"~~~~~~~Employee {i + 1}~~~~~~~");
                employees[i].SetEmployeeDetails();
            }
        }

        //print 5 employees data
        public void PrintEmployeesData()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"~~~~~~~~~~~~~~~~~~~~~~");
                employees[i].PrintEmployeeDetails();
            }
        }

        //Take a skill name and print all teh employee who have the skill
        public void FilterEmployeesBySkill()
        {
            string choice = "yes";
            do
            {
                Console.WriteLine("Please enter skill to filter employees who have it:");
                string skill = Console.ReadLine();
                Employee[] employeesWithSkill = this[skill];//indexer usage
                Console.WriteLine($"Employees with skill: {skill}");
                for(int i = 0; i < employeesWithSkill.Length; i++)
                {
                    if(employeesWithSkill[i]!=null)
                    employeesWithSkill[i].PrintEmployeeDetails();
                }
                Console.WriteLine("Do you want to check one more skill?(print no to exit)");
                choice = Console.ReadLine();
            } while (choice != "no");
        }
    }
    

    class Algorithm 
    {
        //4) write an application that will print the only unique in given 11 numbers
        //PS: except 1 number all the 5 numbers have duplicate values
        //each number is duplicated only once
        //Example
        //1,5,7,8,9,1,2,5,9,7,2
        //The number is 8
        public int FindUnique(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                bool hasDuplicate = false;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        hasDuplicate = true;
                    }
                }
                if (hasDuplicate == false)
                {
                    Console.WriteLine($"{arr[i]} is unique in array");
                    return i;
                }

            }
            return -1;
        }

        //5) Take a 4 digit number and check if it is a plaindrome
        public bool isPalindrome()
        {
            
            int number;
            do
            {
                Console.WriteLine("Enter a 4 digit number: ");
                Int32.TryParse(Console.ReadLine(),out number);
            } while (number.ToString().Length!=4);
            int copy_number = number;
            int new_int = 0;
            while (number > 0)
            {
                int last_digit = number % 10;
                new_int = new_int * 10 + last_digit;
                number = number / 10;
            }

            if (copy_number == new_int)
            {
                Console.WriteLine($"{copy_number} is Palindrome");
                return true;
            }
            else
            {
                Console.WriteLine($"{copy_number} is not Palindrome");
                return false;
            }
        }
    }

        //6) Create an application that will allow the user to play cow an bull(only for 4 char word)
        //Same char same position - cow
        //Same char diff position - bull
        //Example - If the word is - golf
        //Start the guess
        //heap
        //cows - 0, bulls - 0
        //kite
        //cows - 0, bulls -0
        //girl
        //cows - 1, bulls -1
        //like
        //cows -0, bulls 1
        //milk
        //cows -1, bull -0
        //goat
        //cows -2, bulls - 0
        //gold
        //cows -3, bulls-0
        //golf
        //cows -4, bulls -0
        //Congrats!!! you won!!!!!

    class WordGame
    {
        string[] words = { "milk", "love", "time", "rain", "Tree", "Race", "Rice", "Keep", "Game", "Ride", "Hide ", "Exit" };
        static Random random = new Random();
        string current_word = "";
        int cows, bulls;
        public WordGame()
        {            
            int current_word_index = random.Next(words.Length);
            current_word = words[current_word_index].ToLower().Trim();
            //Console.WriteLine(current_word);
            Console.WriteLine("Start the guess - only 4 char words");
            do
            {
                int[] already_counted_indexes = { -1, -1, -1, -1 };
                int last_index_al = -1;
                string user_word = Console.ReadLine();
                while (user_word.Length!=4)
                {
                    Console.WriteLine("Only 4 char words!!! Enter again, please");
                    user_word = Console.ReadLine();
                }
                cows = 0;
                bulls = 0;
                user_word = user_word.ToLower().Trim();
                for (int i = 0; i < current_word.Length; i++)
                {
                    for (int j = 0; j < user_word.Length; j++)
                    {
                        if(current_word[i]==user_word[j] && i == j && !already_counted_indexes.Contains(j))
                        {
                            ++cows;
                            ++last_index_al;
                            already_counted_indexes[last_index_al] = j;
                            break;
                        }
                        else if (current_word[i] == user_word[j] && i != j && !already_counted_indexes.Contains(j))
                        {
                            ++bulls;
                            ++last_index_al;
                            already_counted_indexes[last_index_al] = j;
                            break;
                        }
                    }
                }

                Console.WriteLine($"Cows-{cows},Bulls-{bulls}");

            } while (cows!=current_word.Length);
            Console.WriteLine("Congrats!!! you won!!!!!");
        }
    }
}
