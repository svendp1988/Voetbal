using System;
using System.Collections.Generic;
using System.Linq;

namespace Soccer.Utils
{
    public static class GameUtils
    {
        public static List<MatchDay> ComposeGames(List<Team> teams)
        {
            // We create our matchDays
            List<MatchDay> matchDays = new List<MatchDay>(15);
            int startingDay = 1;
            DateTime day = new DateTime(DateTime.Now.Year, 7, 31);
            while (day.DayOfWeek != DayOfWeek.Saturday)
            {
                day = day.AddDays(-1);
            }


            // Split teams into 2 equal halfs
            List<Team> oneHalf = teams.Select((x, i) => new {x, i}).Where(t => t.i % 2 == 0).Select(t => t.x).ToList();
            List<Team> otherHalf =
                teams.Select((x, i) => new {x, i}).Where(t => t.i % 2 != 0).Select(t => t.x).ToList();

            // Create 15 matchDays and add each to list
            while (startingDay < 16)
            {
                // Create matchDay and add to list
                MatchDay matchDay =
                    new MatchDay(startingDay, oneHalf, otherHalf, new List<int>(), new List<int>(), day);
                matchDays.Add(matchDay);

                // Move order of lists
                MoveTeams(ref oneHalf, ref otherHalf);

                // Increase counter and days
                startingDay++;
                day = day.AddDays(7);
            }

            return matchDays;
        }

        private static void MoveTeams(ref List<Team> oneHalf, ref List<Team> otherHalf)
        {
            var firstToMoveFromOneHalf = oneHalf[1];
            var lastToMoveFromOtherHalf = otherHalf[otherHalf.Count - 1];

            oneHalf.RemoveAt(1);
            oneHalf.Add(lastToMoveFromOtherHalf);
            otherHalf.RemoveAt(otherHalf.Count - 1);
            otherHalf.Insert(0, firstToMoveFromOneHalf);
        }
    }
}