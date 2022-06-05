using System;
using System.Collections.Generic;

namespace Soccer
{
    public class Team : IComparable<Team>
    {
        private const int TiePoints = 1;
        private const int WinningPoints = 3;

        public Team(int id, string name, int points, List<Player> players)
        {
            Id = id;
            Name = name;
            Points = points;
            Players = players;
        }

        public Team(int id, string name) : this(id, name, 0, new List<Player>())
        {
        }

        public int Id { get; }
        public string Name { get; }
        public int Points { get; set; }
        public List<Player> Players { get; }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void AddWin()
        {
            Points += WinningPoints;
        }

        public void AddTie()
        {
            Points += TiePoints;
        }

        public int CompareTo(Team other)
        {
            return other.Points.CompareTo(Points);
        }
    }
}