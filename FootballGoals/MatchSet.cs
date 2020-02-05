using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballGoals.UI
{
    public class MatchSet
    {
        private string _bet;
        private Match[] _matches;

        public MatchSet(string bet)
        {
            if (bet == null
                || bet.Length != 12
                || bet.Any(c => !"HUB".Contains(c)))
            {
                throw new ArgumentException("Unvalid parameter bet: " + bet);
            }

            _bet = bet.ToUpper();
            _matches = new Match[12];
            for (var i = 0; i < _matches.Length; i++)
            {
                _matches[i] = new Match(i + 1, bet[i]);
            }
        }

        public int CorrectCount
            => _matches.Aggregate(0,
                (count, match) => count + (match.IsBetCorrect ? 1 : 0));

        public string GetText()
        {
            var text = "";
            foreach (var match in _matches)
            {
                text += match.GetTextLine() + "\n";
            }
            text += $"Du har {CorrectCount} rette.";
            return text;
        }

        public bool AddGoal(string teamAndMatch)
        {
            if (teamAndMatch.Length == 0) return false;
            var matchNoStr = teamAndMatch.Substring(1);
            if (!int.TryParse(matchNoStr, out int matchNo)) return false;
            var match = _matches[matchNo - 1];
            return match.AddGoal(teamAndMatch[0]);
        }
    }
}
