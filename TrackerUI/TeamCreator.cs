using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerUI.Interfaces;

namespace TrackerUI
{
    public partial class TeamCreator : Form
    {
        ITeamRequestor callingRequestor;

        private List<Person> availablePersons = new List<Person>();
        private List<Person> teamMembers = new List<Person>();

        public TeamCreator(ITeamRequestor caller)
        {
            InitializeComponent();
            LoadAllPersonsList();
            LinkLists();

            callingRequestor = caller;
        }

        private void SampleData()
        {
            availablePersons.Add(new Person { FirstName = "Felix", LastName = "Dreiling" });
            availablePersons.Add(new Person { FirstName = "Drouk", LastName = "Drooklyn" });
            teamMembers.Add(new Person { FirstName = "Juk", LastName = "Dante" });
        }

        private void LoadAllPersonsList()
        {
            availablePersons = GlobalConfig.Connection.GetAllPersons();
        }

        private void LinkLists()
        {
            selectMemberComboBox.DataSource = null;
            selectMemberComboBox.DataSource = availablePersons;
            selectMemberComboBox.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;
            teamMembersListBox.DataSource = teamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateNewMemberForm())
            {
                Person p = new Person(firstNameBox.Text, lastNameBox.Text, emailBox.Text, cellphoneBox.Text);

                GlobalConfig.Connection.CreatePerson(p);

                teamMembers.Add(p);

                LinkLists();

                firstNameBox.Text = "";
                lastNameBox.Text = "";
                emailBox.Text = "";
                cellphoneBox.Text = "";
            }
            else
            {
                MessageBox.Show("This form has invalid information");
            }
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            Person p = selectMemberComboBox.SelectedItem as Person;

            if (p != null)
            {
                availablePersons.Remove(p);
                teamMembers.Add(p);

                LinkLists();
            }
        }

        private void removeMemberLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Person p = teamMembersListBox.SelectedItem as Person;

            if (p != null)
            {
                teamMembers.Remove(p);
                availablePersons.Add(p);

                LinkLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            if (ValidateNewTeamForm())
            {
                Team newTeam = new Team(teamNameBox.Text, teamMembers);

                // ID will be added to the Team object during creation
                GlobalConfig.Connection.CreateTeam(newTeam);

                callingRequestor.TeamCompleted(newTeam);

                this.Close();
            }
            else
            {
                MessageBox.Show("This form has invalid information");
            }
        }

        private bool ValidateNewMemberForm()
        {
            bool output = true;

            if (firstNameBox.Text.Length == 0)
            {
                output = false;
            }

            if (lastNameBox.Text.Length == 0)
            {
                output = false;
            }

            if (emailBox.Text.Length == 0)
            {
                output = false;
            }

            if (cellphoneBox.Text.Length == 0)
            {
                output = false;
            }

            return output;
        }

        private bool ValidateNewTeamForm()
        {
            bool output = true;

            if (teamNameBox.Text.Length == 0)
            {
                output = false;
            }

            if ( !(teamMembers.Count > 0) )
            {
                output = false;
            }

            return output;
        }

    }
}
