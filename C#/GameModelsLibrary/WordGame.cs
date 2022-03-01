using System;
using System.Collections.Generic;
using System.Diagnostics;
using ExceptionHandlingLibrary;

namespace GameModelsLibrary
{
    public class WordGame
    {
        static Queue<string> words;
        readonly int  wordLength=4;
        string current_word = "";
        int cows, bulls;
        public WordGame(int word_length)
        {
            words = new Queue<string>();
            cows = 0;
            bulls = 0;
            wordLength = word_length;
        }
        public void AddWord()
        {
            string word="";
            try
            {
                Console.WriteLine("Please enter the word: ");
                word = Console.ReadLine();
                if (word.Length != wordLength)
                {
                    throw new InvalidWordLengthException(word, wordLength);
                }
                words.Enqueue(word);
                Console.WriteLine($"Thank you, the word \"{word}\" was added to the queue");
            }
            catch (InvalidWordLengthException exiwl) 
            {
                Debug.WriteLine(exiwl.Message + "    Word: " + word);
                Console.WriteLine(exiwl.Message);
            }
            

        }
        public void GuessWord()
        {
            if (words.Count == 0)
            {
                Console.WriteLine("Sorry there are currently no words to guess....");
                return;
            }
            current_word = words.Dequeue().ToLower().Trim();
            Console.WriteLine($"Start the guess - only {wordLength} char words");
            do
            {
                Console.WriteLine("Your word: ");
                List<int> already_counted_indexes = new List<int> { };
                string user_word = Console.ReadLine();
                try
                {
                    if (user_word.Length != wordLength)
                    {
                        throw new InvalidWordLengthException(user_word, wordLength);
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
                }                
                catch (InvalidWordLengthException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            } while (cows != current_word.Length);
            Console.WriteLine("Congrats!!! you won!!!!!");            
        }
       

    }
}
