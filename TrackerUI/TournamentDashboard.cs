using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerUI.Interfaces;

namespace TrackerUI
{
    public partial class TournamentDashboard : Form, ITournamentRequestor
    {
        List<Tournament> existingTournaments = new List<Tournament>();

        public TournamentDashboard()
        {
            InitializeComponent();
            LoadAllTournamentsList();
            LinkList();
        }

        private void LoadAllTournamentsList()
        {
            existingTournaments = GlobalConfig.Connection.GetAllTournaments();
        }

        private void LinkList()
        {
            loadTournamentComboBox.DataSource = null;
            loadTournamentComboBox.DataSource = existingTournaments;
            loadTournamentComboBox.DisplayMember = "TournamentName";
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentCreator tcForm = new TournamentCreator(this);
            tcForm.Show();
        }

        public void TournamentCompleted(Tournament newTournament)
        {
            existingTournaments.Add(newTournament);

            LinkList();
        }

        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentViewer tvForm = new TournamentViewer((Tournament)loadTournamentComboBox.SelectedItem);
            tvForm.Show();
        }

        private void refreshTournamentsButton_Click(object sender, EventArgs e)
        {
            LoadAllTournamentsList();
            LinkList();
        }
    }
}
