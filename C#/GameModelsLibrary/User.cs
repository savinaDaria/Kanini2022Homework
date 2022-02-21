using System;
using PersonModelsLibrary;
namespace GameModelsLibrary
{
    public class User : Person
    {
        string password;
        public User()
        {
            Id = 101;
            Name = "admin";
            Age = 18;
            password = Name + Age;
        }

        public User(ManagePerson manager)
        {
            Person person = manager.CreatePerson();
            password = person.Name + person.Age;
            Name = person.Name;
            Age = person.Age;
            Id = person.Id;
            Console.WriteLine(this);
        }

        public bool CheckPassword(string password)
        {
            if (this.password == password) return true;
            return false;
        }

        public override string ToString()
        {
            return ("\n==============User Details==============\n" +
             $"Welcome - your password is your name and age together({password})\n" +
             $"Your id is {Id}\n");
        }

    }
}
