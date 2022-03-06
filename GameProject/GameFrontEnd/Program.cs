using System;
using System;
using GameModelsLibrary;
using GameBL;
namespace GameFrontEnd
{  
    class GameStart
    {
        GameUserBL gameuserBL = new GameUserBL();
        bool loginMenu()
        {
            bool successfullLogin = false;
            int choice = 0;
            string loginMenu = "\n~~~Login to the game~~~\n" +
                                "1) Register\n" +
                                "2) Login\n" +
                                "Please,choose one option:";
            Console.WriteLine(loginMenu);
            Int32.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    successfullLogin = gameuserBL.Register(TakeUserNameAndAgeFromConsole());
                    break;
                case 2:
                    successfullLogin = gameuserBL.CheckLogin(TakeUserIdAndPasswordFromConsole());
                    break;
                default:
                    Console.WriteLine("Invalid option number. Try again");
                    break;
            }
            return successfullLogin;
        }

        bool gameMenu()
        {
            int choice = 0;
            string mainMenu = "\n===Welcome to the game!===\n" +
                                "1) Give Word\n" +
                                "2) Guess word\n" +
                                "3) Exit to Login Menu\n" +
                                "4) Exit Program\n" +
                                "Please,choose one option: ";
            Console.WriteLine(mainMenu);
            Int32.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    gameuserBL.AddWord(GetWordFromConsole());
                    break;
                case 2:
                    gameuserBL.GuessWord();
                    break;
                case 3:
                    Console.WriteLine("~~~~~~~~~~~~Exit to Login Menu~~~~~~~~~~~~");
                    return false;
                case 4:
                    Console.WriteLine("~~~~~~~~~~~~Program Exit~~~~~~~~~~~~");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option number. Try again");
                    break;
            }
            return true;

        }

        void mainMenu( )
        {
            bool loginResult = false;
            do
            {
                loginResult = loginMenu();
            } while (!loginResult);
            bool gameMenuflag = true;
            do
            {
                gameMenuflag = gameMenu();
            } while (gameMenuflag);
            mainMenu();
        }

        User TakeUserIdAndPasswordFromConsole()
        {
            int id;
            string password;
            Console.WriteLine("Please enter id:");
            while (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry for id.Try again");
            }
            Console.WriteLine("Please enter password:");
            password = Console.ReadLine();
            User user = new User();
            user.Id = id;
            user.Password = password;
            return user;
        }

        User TakeUserNameAndAgeFromConsole()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Please enter User Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter User Age:");
            int age;
            while (!Int32.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid entry for age.Try again");
            }
            Console.WriteLine("==================================================");
            User user = new User(name, age);
            return user;
        }

        public string GetWordFromConsole()
        {
            string word = "";
            Console.WriteLine("Please enter the word: ");
            word = Console.ReadLine();
            return word;
        }

        static void Main(string[] args)
        { 
            GameStart p = new GameStart();
            p.mainMenu();
        }
    }    
}
