namespace TrackerUI
{
    partial class TeamCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamCreator));
            teamNameLabel = new Label();
            teamNameBox = new TextBox();
            headerLabel = new Label();
            addMemberButton = new Button();
            selectMemberComboBox = new ComboBox();
            selectMemberLabel = new Label();
            teamGroupBox = new GroupBox();
            createMemberButton = new Button();
            cellphoneBox = new TextBox();
            cellphoneLabel = new Label();
            emailBox = new TextBox();
            emailLabel = new Label();
            lastNameBox = new TextBox();
            lastNameLabel = new Label();
            firstNameBox = new TextBox();
            firstNameLabel = new Label();
            teamMembersListBox = new ListBox();
            removeMemberLink = new LinkLabel();
            teamMembersLabel = new Label();
            createTeamButton = new Button();
            pictureArrowUp = new PictureBox();
            teamGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureArrowUp).BeginInit();
            SuspendLayout();
            // 
            // teamNameLabel
            // 
            teamNameLabel.AutoSize = true;
            teamNameLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            teamNameLabel.ForeColor = SystemColors.GradientActiveCaption;
            teamNameLabel.Location = new Point(12, 76);
            teamNameLabel.Name = "teamNameLabel";
            teamNameLabel.Size = new Size(124, 30);
            teamNameLabel.TabIndex = 13;
            teamNameLabel.Text = "Team Name";
            // 
            // teamNameBox
            // 
            teamNameBox.Location = new Point(12, 109);
            teamNameBox.Name = "teamNameBox";
            teamNameBox.Size = new Size(240, 29);
            teamNameBox.TabIndex = 12;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel.ForeColor = SystemColors.GradientActiveCaption;
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(209, 45);
            headerLabel.TabIndex = 11;
            headerLabel.Text = "Team Creator";
            // 
            // addMemberButton
            // 
            addMemberButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addMemberButton.ForeColor = Color.SteelBlue;
            addMemberButton.Location = new Point(29, 213);
            addMemberButton.Name = "addMemberButton";
            addMemberButton.Size = new Size(207, 30);
            addMemberButton.TabIndex = 19;
            addMemberButton.Text = "Add Member";
            addMemberButton.UseVisualStyleBackColor = true;
            addMemberButton.Click += addMemberButton_Click;
            // 
            // selectMemberComboBox
            // 
            selectMemberComboBox.FormattingEnabled = true;
            selectMemberComboBox.Location = new Point(12, 178);
            selectMemberComboBox.Name = "selectMemberComboBox";
            selectMemberComboBox.Size = new Size(240, 29);
            selectMemberComboBox.TabIndex = 18;
            // 
            // selectMemberLabel
            // 
            selectMemberLabel.AutoSize = true;
            selectMemberLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            selectMemberLabel.ForeColor = SystemColors.GradientActiveCaption;
            selectMemberLabel.Location = new Point(12, 150);
            selectMemberLabel.Name = "selectMemberLabel";
            selectMemberLabel.Size = new Size(187, 25);
            selectMemberLabel.TabIndex = 17;
            selectMemberLabel.Text = "Select Team Member";
            // 
            // teamGroupBox
            // 
            teamGroupBox.Controls.Add(createMemberButton);
            teamGroupBox.Controls.Add(cellphoneBox);
            teamGroupBox.Controls.Add(cellphoneLabel);
            teamGroupBox.Controls.Add(emailBox);
            teamGroupBox.Controls.Add(emailLabel);
            teamGroupBox.Controls.Add(lastNameBox);
            teamGroupBox.Controls.Add(lastNameLabel);
            teamGroupBox.Controls.Add(firstNameBox);
            teamGroupBox.Controls.Add(firstNameLabel);
            teamGroupBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            teamGroupBox.ForeColor = SystemColors.GradientActiveCaption;
            teamGroupBox.Location = new Point(12, 249);
            teamGroupBox.Name = "teamGroupBox";
            teamGroupBox.Size = new Size(240, 217);
            teamGroupBox.TabIndex = 20;
            teamGroupBox.TabStop = false;
            teamGroupBox.Text = "Add New Member";
            // 
            // createMemberButton
            // 
            createMemberButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            createMemberButton.ForeColor = Color.SteelBlue;
            createMemberButton.Location = new Point(17, 174);
            createMemberButton.Name = "createMemberButton";
            createMemberButton.Size = new Size(207, 30);
            createMemberButton.TabIndex = 21;
            createMemberButton.Text = "Create Member";
            createMemberButton.UseVisualStyleBackColor = true;
            createMemberButton.Click += createMemberButton_Click;
            // 
            // cellphoneBox
            // 
            cellphoneBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cellphoneBox.Location = new Point(98, 133);
            cellphoneBox.Name = "cellphoneBox";
            cellphoneBox.Size = new Size(126, 29);
            cellphoneBox.TabIndex = 13;
            // 
            // cellphoneLabel
            // 
            cellphoneLabel.AutoSize = true;
            cellphoneLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cellphoneLabel.ForeColor = SystemColors.GradientActiveCaption;
            cellphoneLabel.Location = new Point(6, 136);
            cellphoneLabel.Name = "cellphoneLabel";
            cellphoneLabel.Size = new Size(80, 21);
            cellphoneLabel.TabIndex = 12;
            cellphoneLabel.Text = "Cellphone";
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailBox.Location = new Point(98, 98);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(126, 29);
            emailBox.TabIndex = 11;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.ForeColor = SystemColors.GradientActiveCaption;
            emailLabel.Location = new Point(6, 101);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(48, 21);
            emailLabel.TabIndex = 10;
            emailLabel.Text = "Email";
            // 
            // lastNameBox
            // 
            lastNameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameBox.Location = new Point(98, 63);
            lastNameBox.Name = "lastNameBox";
            lastNameBox.Size = new Size(126, 29);
            lastNameBox.TabIndex = 9;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.ForeColor = SystemColors.GradientActiveCaption;
            lastNameLabel.Location = new Point(6, 66);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(84, 21);
            lastNameLabel.TabIndex = 8;
            lastNameLabel.Text = "Last Name";
            // 
            // firstNameBox
            // 
            firstNameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameBox.Location = new Point(98, 28);
            firstNameBox.Name = "firstNameBox";
            firstNameBox.Size = new Size(126, 29);
            firstNameBox.TabIndex = 7;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.ForeColor = SystemColors.GradientActiveCaption;
            firstNameLabel.Location = new Point(6, 31);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(86, 21);
            firstNameLabel.TabIndex = 6;
            firstNameLabel.Text = "First Name";
            // 
            // teamMembersListBox
            // 
            teamMembersListBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            teamMembersListBox.FormattingEnabled = true;
            teamMembersListBox.ItemHeight = 20;
            teamMembersListBox.Location = new Point(306, 262);
            teamMembersListBox.Name = "teamMembersListBox";
            teamMembersListBox.Size = new Size(240, 204);
            teamMembersListBox.TabIndex = 21;
            // 
            // removeMemberLink
            // 
            removeMemberLink.AutoSize = true;
            removeMemberLink.Location = new Point(479, 237);
            removeMemberLink.Name = "removeMemberLink";
            removeMemberLink.Size = new Size(67, 21);
            removeMemberLink.TabIndex = 25;
            removeMemberLink.TabStop = true;
            removeMemberLink.Text = "Remove";
            removeMemberLink.LinkClicked += removeMemberLink_LinkClicked;
            // 
            // teamMembersLabel
            // 
            teamMembersLabel.AutoSize = true;
            teamMembersLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            teamMembersLabel.ForeColor = SystemColors.GradientActiveCaption;
            teamMembersLabel.Location = new Point(306, 234);
            teamMembersLabel.Name = "teamMembersLabel";
            teamMembersLabel.Size = new Size(140, 25);
            teamMembersLabel.TabIndex = 24;
            teamMembersLabel.Text = "Team Members";
            // 
            // createTeamButton
            // 
            createTeamButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            createTeamButton.ForeColor = Color.SteelBlue;
            createTeamButton.Location = new Point(306, 109);
            createTeamButton.Name = "createTeamButton";
            createTeamButton.Size = new Size(240, 40);
            createTeamButton.TabIndex = 26;
            createTeamButton.Text = "Create Team";
            createTeamButton.UseVisualStyleBackColor = true;
            createTeamButton.Click += createTeamButton_Click;
            // 
            // pictureArrowUp
            // 
            pictureArrowUp.Image = (Image)resources.GetObject("pictureArrowUp.Image");
            pictureArrowUp.Location = new Point(390, 174);
            pictureArrowUp.Name = "pictureArrowUp";
            pictureArrowUp.Size = new Size(72, 48);
            pictureArrowUp.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureArrowUp.TabIndex = 27;
            pictureArrowUp.TabStop = false;
            // 
            // TeamCreator
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(560, 481);
            Controls.Add(pictureArrowUp);
            Controls.Add(createTeamButton);
            Controls.Add(removeMemberLink);
            Controls.Add(teamMembersLabel);
            Controls.Add(teamMembersListBox);
            Controls.Add(teamGroupBox);
            Controls.Add(addMemberButton);
            Controls.Add(selectMemberComboBox);
            Controls.Add(selectMemberLabel);
            Controls.Add(teamNameLabel);
            Controls.Add(teamNameBox);
            Controls.Add(headerLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "TeamCreator";
            Text = "Team Creator";
            teamGroupBox.ResumeLayout(false);
            teamGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureArrowUp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label teamNameLabel;
        private TextBox teamNameBox;
        private Label headerLabel;
        private Button addMemberButton;
        private ComboBox selectMemberComboBox;
        private Label selectMemberLabel;
        private GroupBox teamGroupBox;
        private TextBox cellphoneBox;
        private Label cellphoneLabel;
        private TextBox emailBox;
        private Label emailLabel;
        private TextBox lastNameBox;
        private Label lastNameLabel;
        private TextBox firstNameBox;
        private Label firstNameLabel;
        private Button createMemberButton;
        private ListBox teamMembersListBox;
        private LinkLabel removeMemberLink;
        private Label teamMembersLabel;
        private Button createTeamButton;
        private PictureBox pictureArrowUp;
    }
}