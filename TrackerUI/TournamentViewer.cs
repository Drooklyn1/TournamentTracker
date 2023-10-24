using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewer : Form
    {
        private Tournament tournament;
        private List<int> rounds;
        private List<Matchup> matchups;
        private Matchup selectedMatchup;

        public TournamentViewer(Tournament loadedTournament)
        {
            InitializeComponent();

            tournament = loadedTournament;

            LoadTournamentData();
        }

        private void LoadTournamentData()
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

        private void LoadMatchups()
        {
            matchups = tournament.Rounds[(int)roundComboBox.SelectedItem - 1];
        }

        private void LinkMatchups()
        {
            matchupListBox.DataSource = null;
            matchupListBox.DataSource = matchups;
            matchupListBox.DisplayMember = "DisplayName";
        }

        private void OpenMatchup()
        {
            selectedMatchup = (Matchup)matchupListBox.SelectedItem;

            if (selectedMatchup != null)
            {
                if (selectedMatchup.Entries.Count > 0)
                {
                    teamOneLabel.Text = selectedMatchup.Entries[0].DisplayName;
                    teamOneScoreBox.Text = selectedMatchup.Entries[0].Score.ToString();

                    if (selectedMatchup.Entries.Count > 1)
                    {
                        teamTwoLabel.Text = selectedMatchup.Entries[1].DisplayName;
                        teamTwoScoreBox.Text = selectedMatchup.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoLabel.Text = "Bye";
                        teamTwoScoreBox.Text = "0";
                    }
                }
            }
        }

        private void PlayMatch()
        {
            if (selectedMatchup != null)
            {
                if (selectedMatchup.Entries.Count == 1)
                {
                    if (selectedMatchup.Entries[0].TeamCompeting != null)
                    {
                        selectedMatchup.Winner = selectedMatchup.Entries[0].TeamCompeting;
                    }
                }
                else if (selectedMatchup.Entries.Count == 2)
                {
                    if (selectedMatchup.Entries[0].TeamCompeting != null && selectedMatchup.Entries[1].TeamCompeting != null)
                    {
                        selectedMatchup.Entries[0].Score = int.Parse(teamOneScoreBox.Text);
                        selectedMatchup.Entries[1].Score = int.Parse(teamTwoScoreBox.Text);

                        if ( selectedMatchup.Entries[0].Score > selectedMatchup.Entries[1].Score )
                        {
                            selectedMatchup.Winner = selectedMatchup.Entries[0].TeamCompeting;
                        }
                        else if ( selectedMatchup.Entries[1].Score > selectedMatchup.Entries[0].Score )
                        {
                            selectedMatchup.Winner = selectedMatchup.Entries[1].TeamCompeting;
                        }
                    }
                }
            }
        }

        private void roundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups();
            LinkMatchups();
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenMatchup();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            PlayMatch();
            LinkMatchups();
        }
    }
}