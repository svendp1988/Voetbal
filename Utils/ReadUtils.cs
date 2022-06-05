using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Soccer.Utils
{
    public static class ReadUtils
    {
        public static List<Player> ReadPlayers(ref List<Team> teams)
        {
            List<Player> players = new List<Player>();
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, "Players.txt");
            StreamReader playerReader = new StreamReader(filePath, Encoding.Default);
            try
            {
                string line = playerReader.ReadLine();
                while (line != null)
                {
                    var strings = line.Split(',');
                    int id = Convert.ToInt32(strings[0]);
                    int shirtNumber = Convert.ToInt32(strings[1]);
                    string firstName = strings[2];
                    string name = strings[3];
                    PlayerFunction function = (PlayerFunction) strings[4][0];
                    Player player = new Player(name, firstName, shirtNumber, function);
                    ProcessPlayer(player, id, ref teams, ref players);
                    line = playerReader.ReadLine();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                playerReader.Close();
            }

            return players;
        }

        private static void ProcessPlayer(Player player, int id, ref List<Team> teams, ref List<Player> players)
        {
            Team playerTeam = teams.Find(team => team.Id == id);
            playerTeam.AddPlayer(player);
            players.Add(player);
        }

        public static List<Team> ReadTeams()
        {
            List<Team> teams = new List<Team>();
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, "Teams.txt");
            StreamReader teamReader = new StreamReader(filePath, Encoding.Default);
            try
            {
                string line = teamReader.ReadLine();
                while (line != null)
                {
                    var strings = line.Split(',');
                    teams.Add(new Team(Convert.ToInt32(strings[0]), strings[1]));
                    line = teamReader.ReadLine();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                teamReader.Close();
            }

            return teams;
        }
    }
}