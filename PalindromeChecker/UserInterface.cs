using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PalindromeChecker
{
    public class UserInterface
    {
        public List<string> wordsUsed = new List<string>();
        public void Welcome()
        {
            Console.Write("Welcome to the Palindrome Checker!\n\nPut in any word and we will see if it is the same forward as backwards!\n\n");
        }
        public void AddWord()
        {
            string currWord = "";
            string choice = "";
            int resultOfPalinCheck = 0;

            while (true)
            {
                currWord = TakeWord();
                bool checkFlag = CheckWord(currWord);
                if (checkFlag == true)
                {
                    wordsUsed.Add(currWord);
                    resultOfPalinCheck = CheckForPalin(currWord);
                    if(resultOfPalinCheck == 1)
                    {
                        IsAPalindrome();
                    }else if(resultOfPalinCheck == 2)
                    {
                        IsNotAPalindrome();
                    }
                }
            }
            
        }
        public string TakeWord()
        {
            string result = "";
            Console.Write("Add your word now: ");
            result = Console.ReadLine();
            Console.Clear();
            return result;
        }
        public bool CheckWord(string word)
        {
            while (true)
            {
                Console.WriteLine($"\nIs this the word you wanted to check: {word}?\n");
                Console.Write("Y for Yes and N for No: ");
                string choice = Console.ReadLine();
                if (choice == "Y")
                {
                    Console.Clear();
                    return true;
                }
                else if (choice == "N")
                {
                    Console.Clear();
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid option. Try Again.\n");
                }
            }
        }
        public int CheckForPalin(string word)
        {
            int length = word.Length;
            string firstHalf = "";
            string lastHalf = "";
            if (length <= 1)
            {
                WaitingEffect();
                Console.WriteLine("You put 1 or less characters. Does not count.\n");
                return 0;
            }
            else if(length%2 == 0)
            {
                firstHalf = word.Substring(0, word.Length / 2);
                lastHalf = FlipLastHalf(word);
                WaitingEffect();
            }
            else
            {
                firstHalf = word.Substring(0, (word.Length / 2)+1);
                lastHalf = FlipLastHalf(word);
                WaitingEffect();
            }
            if (firstHalf == lastHalf)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public void IsAPalindrome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your word was a Palindrome!\n");
            Console.ResetColor();
        }
        public void IsNotAPalindrome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your word was not a Palindrome!\n");
            Console.ResetColor();
        }
        public string FlipLastHalf(string word)
        {
            string lastHalf = "";
            string result = "";
            int length = word.Length;

            lastHalf = word.Substring(length / 2);
            for(int i = 1; i<=lastHalf.Length; i++)
            {
                result += lastHalf[lastHalf.Length - i];
            }
            return result;
        }
        public void WaitingEffect()
        {
            Console.Write("Calculating...");
            Thread.Sleep(2000);
            Console.WriteLine("...");
            Thread.Sleep(1000);
        }
    }
}

