using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerUI.Interfaces;

namespace TrackerUI
{
    public partial class TournamentCreator : Form, IPrizeRequestor, ITeamRequestor
    {
        List<Team> availableTeams = new List<Team>();
        List<Team> tournamentTeams = new List<Team>();
        List<Prize> tournamentPrizes = new List<Prize>();

        ITournamentRequestor callingRequestor;

        public TournamentCreator()
        {
            InitializeComponent();
            LoadAllTeamsList();
            LinkLists();
        }

        public TournamentCreator(ITournamentRequestor caller)
        {
            callingRequestor = caller;

            InitializeComponent();
            LoadAllTeamsList();
            LinkLists();
        }

        private void LoadAllTeamsList()
        {
            availableTeams = GlobalConfig.Connection.GetAllTeams();
        }

        private void LinkLists()
        {
            selectTeamComboBox.DataSource = null;
            selectTeamComboBox.DataSource = availableTeams;
            selectTeamComboBox.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = tournamentTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            tournamentPrizesListBox.DataSource = null;
            tournamentPrizesListBox.DataSource = tournamentPrizes;
            tournamentPrizesListBox.DisplayMember = "PlaceName";
        }

        private void createTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TeamCreator tcForm = new TeamCreator(this);
            tcForm.Show();
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            Team t = selectTeamComboBox.SelectedItem as Team;

            if (t != null)
            {
                availableTeams.Remove(t);
                tournamentTeams.Add(t);

                LinkLists();
            }
        }

        private void removeTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Team t = tournamentTeamsListBox.SelectedItem as Team;

            if (t != null)
            {
                tournamentTeams.Remove(t);
                availableTeams.Add(t);

                LinkLists();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeCreator pcForm = new PrizeCreator(this);
            pcForm.Show();
        }

        private void removePrizeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Prize p = tournamentPrizesListBox.SelectedItem as Prize;

            if (p != null)
            {
                tournamentPrizes.Remove(p);

                LinkLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            if (ValidateNewTournamentForm())
            {
                Tournament newTournament = new Tournament(tournamentNameBox.Text, decimal.Parse(entryFeeBox.Text), tournamentTeams, tournamentPrizes);

                // Create rounds and matchups
                TournamentLogic.CreateRounds(newTournament);

                // Save the tournament to SQL or Files
                GlobalConfig.Connection.CreateTournament(newTournament);

                // Update the dashboard
                callingRequestor.TournamentCompleted(newTournament);

                // Email all users
                TournamentLogic.FirstRoundAlert(0, newTournament);

                TournamentViewer tvForm = new TournamentViewer(newTournament);
                tvForm.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("This form has invalid information");
            }
        }

        private bool ValidateNewTournamentForm()
        {
            bool output = true;
            decimal fee;

            output = decimal.TryParse(entryFeeBox.Text, out fee);

            if (tournamentNameBox.Text.Length == 0)
            {
                output = false;
            }

            if (tournamentTeams.Count <= 0)
            {
                output = false;
            }

            return output;
        }

        public void PrizeCompleted(Prize newPrize)
        {
            tournamentPrizes.Add(newPrize);

            LinkLists();
        }

        public void TeamCompleted(Team newTeam)
        {
            tournamentTeams.Add(newTeam);

            LinkLists();
        }

    }
}
