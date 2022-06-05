using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Soccer.Utils;

namespace Soccer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MaximumNumberOfPlayers = 11;
        private List<Team> _teams;
        private List<MatchDay> _games;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReadTeams_Click(object sender, RoutedEventArgs e)
        {
            _teams = ReadUtils.ReadTeams();
            ReadUtils.ReadPlayers(ref _teams);
            CompetitionMenu.IsEnabled = true;
        }

        private void ComposeGames_OnClick(object sender, RoutedEventArgs e)
        {
            _games = GameUtils.ComposeGames(_teams);
            _games.ForEach(game => matchDaysListBox.Items.Add($"Match day {game.DayNumber}: {game.Date:dd/MM/yyyy}"));
        }

        private void EnterScores_OnClick(object sender, RoutedEventArgs e)
        {
            EnterGameScores();
        }

        private void Ranking_OnClick(object sender, RoutedEventArgs e)
        {
            RankingWindow rankingWindow = new RankingWindow(_teams);
            rankingWindow.Show();
            rankingWindow.Closed += (o, args) => this.Show();
            this.Hide();
        }

        private void MatchDaysListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wedstrijdenListBox.Items.Clear();
            var matchDay = GetMatchDay();
            List<Team> teams1 = matchDay.TeamList1;
            List<Team> teams2 = matchDay.TeamList2;
            for (int i = 0; i < teams1.Count; i++)
            {
                string game = $"{teams1[i].Name} -  {teams2[i].Name}";
                wedstrijdenListBox.Items.Add(game);
            }
        }

        private void WedstrijdenListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EnterGameScores();
        }

        private void EnterGameScores()
        {
            var teams = Array.ConvertAll(wedstrijdenListBox.SelectedItem.ToString().Split('-'), input => input.Trim());
            Team team1 = _teams.Find(team => team.Name.Equals(teams[0]));
            Team team2 = _teams.Find(team => team.Name.Equals(teams[1]));
            GameWindow gw = new GameWindow(team1, team2);
            gw.Show();
            gw.Closed += (o, args) => this.Show();
            this.Hide();
        }

        private MatchDay GetMatchDay()
        {
            var gameDay = Convert.ToInt32(((string) matchDaysListBox.SelectedItem).Split(':')[0].Split(' ')[2]);
            MatchDay matchDay = _games.Find(game => game.DayNumber == gameDay);
            return matchDay;
        }
    }
}