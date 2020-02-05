using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGoals
{
    public class Match
    {
        private int _matchNo;

        public Match(int matchNo, char bet)
        {
            _matchNo = matchNo;
        }

        public bool IsBetCorrect = true;

        public string GetTextLine()
        {
            return $"Kamp {_matchNo:D2} 0-0 U Riktig";
        }
    }
}
