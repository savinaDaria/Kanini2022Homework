using System;

public class Class1
{
    class WordGame
    {
        string[] words = { "milk", "love", "time", "rain", "Tree", "Race", "Rice", "Keep", "Game", "Ride", "Hide ", "Exit" };
        static Random random = new Random();
        string current_word = "";
        int cows, bulls;
        public WordGame()
        {
            int current_word_index = random.Next(words.Length);
            current_word = words[current_word_index].ToLower().Trim();
            //Console.WriteLine(current_word);
            Console.WriteLine("Start the guess - only 4 char words");
            do
            {
                int[] already_counted_indexes = { -1, -1, -1, -1 };
                int last_index_al = -1;
                string user_word = Console.ReadLine();
                while (user_word.Length != 4)
                {
                    Console.WriteLine("Only 4 char words!!! Enter again, please");
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
                            ++last_index_al;
                            already_counted_indexes[last_index_al] = j;
                            break;
                        }
                        else if (current_word[i] == user_word[j] && i != j && !already_counted_indexes.Contains(j))
                        {
                            ++bulls;
                            ++last_index_al;
                            already_counted_indexes[last_index_al] = j;
                            break;
                        }
                    }
                }

                Console.WriteLine($"Cows-{cows},Bulls-{bulls}");

            } while (cows != current_word.Length);
            Console.WriteLine("Congrats!!! you won!!!!!");
        }
    }
}
