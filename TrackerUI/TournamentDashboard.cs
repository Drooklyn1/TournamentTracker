using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            LinkLists();
        }

        private void LoadAllTournamentsList()
        {
            existingTournaments = GlobalConfig.Connection.GetAllTournaments();
        }

        private void LinkLists()
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

            LinkLists();
        }

    }
}
