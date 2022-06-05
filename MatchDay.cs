using System;
using System.Collections.Generic;

namespace Soccer
{
    public class MatchDay
    {
        public MatchDay(int dayNumber, List<Team> teamList1, List<Team> teamList2, List<int> scoresList1,
            List<int> scoresList2, DateTime date)
        {
            DayNumber = dayNumber;
            TeamList1 = teamList1;
            TeamList2 = teamList2;
            ScoresList1 = scoresList1;
            ScoresList2 = scoresList2;
            Date = date;
        }

        public int DayNumber { get; }
        public List<Team> TeamList1 { get; }
        public List<Team> TeamList2 { get; }
        public List<int> ScoresList1 { get; }
        public List<int> ScoresList2 { get; }
        public DateTime Date { get; }
    }
}