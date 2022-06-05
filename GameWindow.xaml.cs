using System.Windows;
using System.Windows.Input;

namespace Soccer
{
    /// <summary>
    /// Interaction logic for WedstrijdWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Team _team1;
        private Team _team2;
        private int _scoreTeam1 = 0;
        private int _scoreTeam2 = 0;

        public GameWindow(Team team1, Team team2)
        {
            InitializeComponent();

            _team1 = team1;
            _team2 = team2;

            BindCurrentTeams(team1, team2);
        }

        private void BindCurrentTeams(Team team1, Team team2)
        {
            scoreT1Label.Content = _scoreTeam1;
            scoreT2Label.Content = _scoreTeam2;
            team1Label.Content = team1.Name;
            team2Label.Content = team2.Name;

            team1.Players.ForEach(player => playersTeam1ListBox.Items.Add($"{player.Name} {player.FirstName}"));
            team2.Players.ForEach(player => playersTeam2ListBox.Items.Add($"{player.Name} {player.FirstName}"));
        }

        private void PlayersTeam1ListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _scoreTeam1++;
            scoreT1Label.Content = _scoreTeam1;
        }

        private void PlayersTeam2ListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _scoreTeam2++;
            scoreT2Label.Content = _scoreTeam2;
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_scoreTeam1 == _scoreTeam2)
            {
                _team1.AddTie();
                _team2.AddTie();
            }
            else if (_scoreTeam1 > _scoreTeam2)
            {
                _team1.AddWin();
            }
            else
            {
                _team2.AddWin();
            }

            this.Close();
        }
    }
}