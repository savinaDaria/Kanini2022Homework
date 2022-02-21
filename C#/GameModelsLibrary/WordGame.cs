using System;
using System.Collections.Generic;

namespace GameModelsLibrary
{
    public class WordGame
    {
        static Queue<string> words;
        string current_word = "";
        int cows, bulls;
        public void AddWord()
        {
            Console.WriteLine("Please enter the word: ");
            string word = Console.ReadLine();
            while (word.Length!=4)
            {
                Console.WriteLine("Please enter only 4 char words! try again");
                word = Console.ReadLine();
            }            
            words.Enqueue(word);
            Console.WriteLine($"Thank you the word \"{word}\" was added to the queue");
        }
        public void GuessWord()
        {
            if (words.Count == 0)
            {
                Console.WriteLine("Sorry there are currently no words to guess....");
                return;
            }
            current_word = words.Dequeue().ToLower().Trim();
            //Console.WriteLine(current_word);
            Console.WriteLine("Start the guess - only 4 char words");
            do
            {
                List<int> already_counted_indexes = new List<int> { };
                string user_word = Console.ReadLine();
                while (user_word.Length != 4)
                {
                    Console.WriteLine("Only 4 char words! Enter again, please");
                    user_word = Console.ReadLine();
                }
                cows = 0;
                bulls = 0;
                user_word = user_word.ToLower().Trim();
                for (int i = 0; i < current_word.Length; i++)
                {
                    for (int j = 0; j < user_word.Length; j++)
                    {
                        if (current_word[i] == user_word[j] && i == j && !already_counted_indexes.Contains(j))
                        {
                            ++cows;
                            already_counted_indexes.Add(j);
                            break;
                        }
                        else if (current_word[i] == user_word[j] && i != j && !already_counted_indexes.Contains(j))
                        {
                            ++bulls;
                            already_counted_indexes.Add(j);
                            break;
                        }
                    }
                }

                Console.WriteLine($"Cows-{cows},Bulls-{bulls}");

            } while (cows != current_word.Length);
            Console.WriteLine("Congrats!!! you won!!!!!");
        }
        public WordGame()
        {
            words = new Queue<string>();
            cows = 0;
            bulls = 0;
        }

    }
}
