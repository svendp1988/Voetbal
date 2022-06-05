using System.Collections.Generic;
using System.Windows;

namespace Soccer
{
    /// <summary>
    /// Interaction logic for RangschikkingWindow.xaml
    /// </summary>
    public partial class RankingWindow : Window
    {
        private List<Team> _teams;

        public RankingWindow(List<Team> teams)
        {
            InitializeComponent();

            _teams = teams;
            _teams.Sort();

            BindCurrentTeam();
        }

        private void BindCurrentTeam()
        {
            rankingTextBox.Text = "";
            _teams.ForEach(team => rankingTextBox.Text += $"{team.Points}    {team.Name}\n");
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}