using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewer : Form
    {
        private Tournament tournament;
        private List<int> rounds = new List<int>();
        private List<Matchup> selectedMatchups = new List<Matchup>();
        private Matchup selectedMatchup = new Matchup();
        private int selectedRound;

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
            // Load Matchups of the current round (round 1 -> spot 0 in List<Matchup>)

            selectedRound = (int)roundComboBox.SelectedItem;

            if (roundCheckBox.Checked)
            {
                selectedMatchups = tournament.Rounds[selectedRound - 1].Where(x => x.Winner == null).ToList();
            }
            else
            {
                selectedMatchups = tournament.Rounds[selectedRound - 1];
            }
        }

        private void LinkMatchups()
        {
            matchupListBox.DataSource = null;
            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }

        private void OpenMatchup()
        {
            selectedMatchup = (Matchup)matchupListBox.SelectedItem;

            if (selectedMatchup != null)
            {
                // Load the Teams and Scores of the Matchup to the UI

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
            // Capture and save the Scores

            if (selectedMatchup.Entries.Count == 2)
            {
                string error = ValidateScore();

                if (error == "")
                {
                    selectedMatchup.Entries[0].Score = int.Parse(teamOneScoreBox.Text);
                    selectedMatchup.Entries[1].Score = int.Parse(teamTwoScoreBox.Text);
                }
                else
                {
                    MessageBox.Show(error);
                    return;
                }
            }

            try
            {
                LogicProcessor.UpdateResult(selectedMatchup, tournament); 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private string ValidateScore()
        {
            string output = "";

            if ( !double.TryParse(teamOneScoreBox.Text, out double scoreOne) )
            {
                output = "Please enter a valid score for team 1.";
            }
            else if ( !double.TryParse(teamTwoScoreBox.Text, out double scoreTwo) )
            {
                output = "Please enter a valid score for team 2.";
            }
            else if (scoreOne == scoreTwo)
            {
                output = "Ties are not allowed in this tournament.";
            }

            return output;
        }

        private void roundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups();
            LinkMatchups();
        }

        private void roundCheckBox_CheckedChanged(object sender, EventArgs e)
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
            LoadMatchups();
            LinkMatchups();
        }

    }
}