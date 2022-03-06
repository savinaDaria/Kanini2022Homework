using ExceptionHandlingLibrary;
using GameDAL;
using GameModelsLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace GameBL
{
    public class GameUserBL
    {      
        UserDAL userDAL;
        WordDAL wordDAL;
        Queue<Word> words = new Queue<Word>();
        public GameUserBL()
        {
            userDAL = new UserDAL();
            wordDAL = new WordDAL();
        }
        public bool CheckLogin(User user)
        {
            int userCount = userDAL.GetAllUsersCount();
            if (userCount>0 && user.Id != 0 && user.Password != null)
            {
                string result = userDAL.LoginUser(user);
                if (result == null)
                {
                    return false;
                }
                else
                {
                    user.Name = result;
                    user.Password = "";
                    Console.WriteLine("Successfully logged in!");
                    Console.WriteLine(user);
                    return true;
                }
            }
            if (userCount == 0) Console.WriteLine("There are no registered users yet");
            return false;
        }

        public bool Register(User user)
        {
            if (user.Age > 0 && user.Name!= null)
            {
                int resultid = userDAL.RegisterUser(user);
                if (resultid == 0)
                {
                    Console.WriteLine("can`t register you");
                    return false;
                }
                else
                {
                    user.Id = resultid;
                    Console.WriteLine(user);
                    return true;
                }
            }
            return false;
        }

        public bool AddWord(string word)
        {
            try
            {
                if (word.Length != 4)
                {
                    throw new InvalidWordLengthException(word, 4);
                }
                int id = wordDAL.AddWord(word);
                if (id > 0)
                {
                    Word w = new Word();
                    w.Id = id;
                    w.word = word;
                    words.Enqueue(w);
                    Console.WriteLine($"Thank you, the word \"{word}\" was added to the queue");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidWordLengthException exiwl)
            {
                Debug.WriteLine(exiwl.Message + "    Word: " + word);
                Console.WriteLine(exiwl.Message);
            }
            return false;

        }

        public string GetAndRemoveWord()
        {
            Word word= words.Dequeue();
            int result = wordDAL.RemoveWord(word.Id);
            if (result < 1)
            {
                Console.WriteLine("There is no word with this id");
            }
            return word.word;
        }

        public int GetWords()
        {
            DataSet dsWords=wordDAL.GetAllWords();
            foreach (DataRow dr in dsWords.Tables[0].Rows)
            {
                Word word = new Word();
                word.Id = (int)dr[0];
                word.word = dr[1].ToString();
                words.Enqueue(word);
            }
            return words.Count;
        }

        public void GuessWord()
        {
            int count=GetWords();
            int wordLength = 4;
            string current_word = "";
            int cows=0, bulls=0;
            if (count == 0)
            {
                Console.WriteLine("Sorry there are currently no words to guess....");
                return;
            }
            current_word = GetAndRemoveWord();
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
            } while (cows != wordLength);
            Console.WriteLine("Congrats!!! you won!!!!!");
        }
    }
}
