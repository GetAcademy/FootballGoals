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
            var usersCombination = Console.ReadLine()?.ToUpper();

            if (usersCombination == null
                || usersCombination.Length != 12
                || usersCombination.Any(c => !"HUB".Contains(c)))
            {
                usersCombination = "HUBHHHUUUBBB";
                Console.WriteLine($"Ugyldig rekke. Bruker {usersCombination}");
            }

            while (true)
            {
                Console.Write("Skriv inn H eller B og kampnr., for eksempel \"H10\":");
                var input = Console.ReadLine()?.ToUpper();
                Console.Clear();
                Console.WriteLine($"Du skrev: {input}");
                if (input.Length < 2) continue;
                var homeOrAwayGoal = input[0];
                if (!"HB".Contains(homeOrAwayGoal)) continue;
                var matchNoStr = input.Substring(1);
                if (!int.TryParse(matchNoStr, out int matchNo)) continue;
                if (matchNo < 1 || matchNo > 12) continue;
                var goalsArray = homeOrAwayGoal == 'H' ? homeGoals : awayGoals;
                goalsArray[matchNo - 1]++;
                int correctCount = 0;
                for (var i = 0; i < homeGoals.Length; i++)
                {
                    var goalsH = homeGoals[i];
                    var goalsA = awayGoals[i];
                    var currentResult = goalsH == goalsA ? 'U' : goalsH > goalsA ? 'H' : 'B';
                    var usersGuess = usersCombination[i];
                    var isCorrect = usersGuess == currentResult;
                    var isCorrectText = isCorrect ? "Riktig" : $"Feil (Du tippet {usersGuess})";
                    Console.WriteLine($"Kamp {(i + 1):D2} {goalsH}-{goalsA} {currentResult} {isCorrectText}");
                    if (isCorrect) correctCount++;
                }

                Console.WriteLine($"Du har {correctCount} rette.");
            }
        }
    }
}
