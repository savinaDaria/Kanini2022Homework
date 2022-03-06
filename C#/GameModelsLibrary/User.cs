using System;
namespace GameModelsLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        string password;
        public User()
        {
            Id = 101;
            Name = "admin";
            Age = 18;
            password = Name + Age;
        }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
            password = Name + Age;
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
             $"Welcome {Name} your password is your name and age together({password})\n" +
             $"Your id is {Id}\n");
        }

    }
}
