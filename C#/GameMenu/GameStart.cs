using System;
using GameModelsLibrary;
namespace GameMenu
{
    class GameStart
    {
        bool loginMenu(UserManager userManager)
        {
            bool successfullLogin = false;
            int choice = 0;
            string loginMenu = "\n~~~Login to the game~~~\n" +
                                "1) Register\n" +
                                "2) Login\n"+
                                "Please,choose one option:";
            Console.WriteLine(loginMenu);
            Int32.TryParse(Console.ReadLine(), out choice);
            switch (choice)
                {
                    case 1:
                        successfullLogin=userManager.CreateUser();
                        break;
                    case 2:
                        successfullLogin = userManager.CheckUser();
                        break;
                    default:
                        Console.WriteLine("Invalid option number. Try again");
                        break;
                }
            return successfullLogin;
        }

        bool gameMenu(WordGame wordGame)
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
                    wordGame.AddWord();
                    break;
                case 2:
                    wordGame.GuessWord();
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

        void mainMenu(UserManager userManager, WordGame wordGame)
        {
            bool loginResult=false;
            do 
            {
                loginResult = loginMenu(userManager);
            } while(!loginResult);
            bool gameMenuflag=true;
            do
            {
                gameMenuflag = gameMenu(wordGame);
            } while (gameMenuflag);
            mainMenu(userManager, wordGame);
        }

        static void Main(string[] args)
        {
            GameStart p = new GameStart();                    

            UserManager userManager = new UserManager();
            WordGame wordGame = new WordGame(4);
            p.mainMenu(userManager, wordGame);
        }
    }
}