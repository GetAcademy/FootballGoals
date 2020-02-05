using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGoals
{
    public class Match
    {
        private readonly int _matchNo;
        private readonly char _bet;
        private int _homeGoals;
        private int _awayGoals;

        public char CurrentResult =>
            _homeGoals == _awayGoals ? 'U' :
            _homeGoals > _awayGoals ? 'H' :
            'B';

        public bool IsBetCorrect => _bet == CurrentResult;

        public Match(int matchNo, char bet)
        {
            _bet = bet;
            _matchNo = matchNo;
        }

        public string GetTextLine()
        {
            var isCorrectText = IsBetCorrect ? "Riktig" : $"Feil (Du tippet {_bet})";
            return $"Kamp {_matchNo:D2} {_homeGoals}-{_awayGoals} " 
                   + $"{CurrentResult} {isCorrectText}";
        }

        public bool AddGoal(char teamInput)
        {
            var team = char.ToUpper(teamInput);
            if(!"HB".Contains(team))return false;
            if (team == 'H') _homeGoals++;
            else _awayGoals++;
            return true;
        }
    }
}
