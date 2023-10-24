using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewer : Form
    {
        private Tournament tournament;
        private List<int> rounds;
        private List<string> matchupStrings;

        public TournamentViewer(Tournament loadedTournament)
        {
            InitializeComponent();

            tournament = loadedTournament;

            LoadFormData();
        }

        private void LoadFormData()
        {
            nameLabel.Text = tournament.TournamentName;

            LoadRounds();
            LinkRounds();
        }

        private void LoadRounds()
        {
            rounds = new List<int>();

            foreach (List<Matchup> r in tournament.Rounds)
            {
                if (r.Count > 0) rounds.Add(rounds.Count + 1);
            }
        }

        private void LinkRounds()
        {
            roundComboBox.DataSource = null;
            roundComboBox.DataSource = rounds;
        }

        private void LinkMatchupStrings()
        {
            int round = (int)roundComboBox.SelectedItem;

            matchupListBox.DataSource = null;
            matchupListBox.DataSource = tournament.Rounds[round - 1];
            matchupListBox.DisplayMember = "DisplayName";
        }

        private void roundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkMatchupStrings();
        }
    }
}