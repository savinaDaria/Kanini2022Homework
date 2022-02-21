using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonModelsLibrary;
namespace PersonModelsLibrary
{
    public class ManagePerson
    {
        List<Person> people = new List<Person>();
        protected int GenerateId()
        {
            int id;
            if (people.Count == 0) return 101;
            id = people.Last<Person>().Id + 1;
            return id;

        }
        public Person CreatePerson()
        {
            Person person = new Person();
            person.TakePersonDetailsFromConsole();
            person.Id = GenerateId();
            people.Add(person);            
            return person;
        }
        public void CreatePeople()
        {
            string choice = "yes";            
            do
            {
                Person person = CreatePerson();
                people.Add(person);
                Console.WriteLine("Do you want to enter one more person? enter \"no\" to exit ");
                choice = Console.ReadLine();
            } while (choice != "no");
            PrintPeople();
        }

        void PrintPeople()
        {

            Console.WriteLine("~~~~~~~~~~~People details~~~~~~~~~~~");
            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }
        }
    }
}
