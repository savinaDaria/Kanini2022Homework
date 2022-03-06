using System;
using System.Collections.Generic;
namespace GameModelsLibrary
{
    public class UserManager
    {
        List<User> users = new List<User>();
        public UserManager()
        {
            User user = new User();
            users.Add(user);
        }
        public bool CreateUser()
        {
            User new_user = new User();
            users.Add(new_user);
            return true;
        }
       
        public bool CheckUser()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("Sorry, there are no users yet. Please register first.");
                return false;
            }
            string password;
            int id;
            TakeUserIdAndPasswordFromConsole(out id,out password);
            User user = FindUserById(id);
            if (user != null && user.CheckPassword(password))
            {
                Console.WriteLine("Successfully logged in!");
                return true;
            }
            else if (user != null && !user.CheckPassword(password))
            {
                Console.WriteLine("Invalid password!");
            }
            else
            {
                Console.WriteLine("Can`t find this user!");
            }
            return false;
        }
        private User FindUserById( int id)
        {
            return users.Find(u => u.Id == id);
        }
    }
}
