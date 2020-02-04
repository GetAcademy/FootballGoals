using System;
using System.Linq;

namespace FootballGoals
{
    class Program
    {
        static void Main(string[] args)
        {
            var homeGoals = new int[12];
            var awayGoals = new int[12];
            Console.Write("Skriv først inn rekken du" +
                          " har tippet, for eksempel HUBHUBHUBHUB: ");
            var usersPlayedCombination = Console.ReadLine()?.ToUpper();
            if (usersPlayedCombination == null
                || usersPlayedCombination.Length != 12
                || usersPlayedCombination.Any(c => !"HUB".Contains(c)))
            {
                Console.WriteLine("Ugyldig rekke.");
                return;
            }

            while (true)
            {
                Console.Write("Skriv inn kampnr. og H eller B, for eksempel \"10H\":");
                var input = Console.ReadLine()?.ToUpper();

            }
        }
    }
}
