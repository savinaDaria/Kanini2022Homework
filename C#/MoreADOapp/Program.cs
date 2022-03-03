using ADBLLibrary;
using ADOModelsLibrary;
using System;
using System.Data;

namespace MoreADOapp
{
    class Program
    {
        UserBL userBL;
        public Program()
        {
            userBL = new UserBL();
        }
        void UserLoginCheck()
        {
            User user = GetLoginData();
            user = userBL.CheckLogin(user);
            if (user == null)
            {
                Console.WriteLine("Invalid username or password");
                return;
            }
            Console.WriteLine("Welcome " + user.Username + " you are a " + user.Role);
            DataSet products = userBL.GetProductsIfRoleAdmin(user);
            if (products != null)
            {
                ShowProducts(products);
            }
            else 
            { 
                Console.WriteLine("You don't have enough rights to see all products"); 
            }           

        }

        private User GetLoginData()
        {
            User user = new User();
            Console.WriteLine("Please enter your username");
            user.Username = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            user.Password = Console.ReadLine();
            return user;
        }

        void ShowProducts(DataSet dsProducts)
        {
            foreach (DataRow dr in dsProducts.Tables[0].Rows)
            {
                Console.Write("Product Name " + dr[0].ToString());
                Console.Write("\tQuantityPerUnit " + dr[1].ToString());
                Console.Write("\tUnitPrice " + dr[2].ToString());
                Console.Write("\tUnitsInStock " + dr[3].ToString());
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            new Program().UserLoginCheck();
            Console.ReadKey();
        }
    }
}

