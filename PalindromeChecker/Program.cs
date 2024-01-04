using System;

namespace PalindromeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface user = new UserInterface();
            user.Welcome();
            user.AddWord();
        }
    }
}
