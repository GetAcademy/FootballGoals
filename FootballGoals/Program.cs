using System;
using System.Linq;
using FootballGoals.UI;

namespace FootballGoals
{
    class Program
    {
        static void Main(string[] args)
        {
            var matchSet = CreateMatchSet();

            while (true)
            {
                Console.Write("Skriv inn H eller B og kampnr., for eksempel \"H10\":");
                var answer = Console.ReadLine();
                matchSet.AddGoal(answer);
                Console.Clear();
                Console.WriteLine($"Du skrev: {answer}");
                Console.WriteLine(matchSet.GetText());
            }
        }

        private static MatchSet CreateMatchSet()
        {
            Console.Write("Skriv inn rekken du har tippet, for eksempel HUBHUBHUBHUB: ");
            string bet;
            try
            {
                bet = Console.ReadLine();
                return new MatchSet(bet);
            }
            catch (ArgumentException)
            {
                bet = "HUBHHHUUUBBB";
                Console.WriteLine($"Ugyldig rekke. Bruker {bet}");
                return new MatchSet(bet);
            }
        }
    }
}
