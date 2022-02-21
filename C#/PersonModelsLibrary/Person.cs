using System;

namespace PersonModelsLibrary
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {

            return "\n==============Person Details==============\n" +
             "\nId: " + Id +
             "\nName: " + Name +
             "\nAge: " + Age + "\n";
        }

        public void TakePersonDetailsFromConsole()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Please enter Person Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter Person Age(integer):");
            int age;
            while (!Int32.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid entry for age.Try again");
            }
            Age = age;
            Console.WriteLine("==================================================");
        }
    }
}
