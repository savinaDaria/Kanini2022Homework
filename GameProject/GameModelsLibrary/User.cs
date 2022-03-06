using System;
namespace GameModelsLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Password;
        public User()
        {
            Id = 0;
            Password = "";
        }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
            Password = Name + Age;
        }

        public bool CheckPassword(string password)
        {
            if (this.Password == password) return true;
            return false;
        }

        public override string ToString()
        {
            return ("\n==============User Details==============\n" +
             $"Welcome {Name} your password is your name and age together\n" +
             $"Your id is {Id}\n");
        }

    }
}
