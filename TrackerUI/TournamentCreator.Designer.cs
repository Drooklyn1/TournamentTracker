namespace TrackerUI
{
    partial class TournamentCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentCreator));
            headerLabel = new Label();
            tournamentNameLabel = new Label();
            tournamentNameBox = new TextBox();
            entryFeeLabel = new Label();
            entryFeeBox = new TextBox();
            selectTeamComboBox = new ComboBox();
            selectTeamLabel = new Label();
            createTeamLink = new LinkLabel();
            addTeamButton = new Button();
            createPrizeButton = new Button();
            tournamentTeamsListBox = new ListBox();
            tournamentTeamsLabel = new Label();
            tournamentPrizesLabel = new Label();
            tournamentPrizesListBox = new ListBox();
            removeTeamLink = new LinkLabel();
            removePrizeLink = new LinkLabel();
            createTournamentButton = new Button();
            pictureArrowUp = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureArrowUp).BeginInit();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel.ForeColor = SystemColors.GradientActiveCaption;
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(304, 45);
            headerLabel.TabIndex = 2;
            headerLabel.Text = "Tournament Creator";
            // 
            // tournamentNameLabel
            // 
            tournamentNameLabel.AutoSize = true;
            tournamentNameLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentNameLabel.ForeColor = SystemColors.GradientActiveCaption;
            tournamentNameLabel.Location = new Point(12, 76);
            tournamentNameLabel.Name = "tournamentNameLabel";
            tournamentNameLabel.Size = new Size(186, 30);
            tournamentNameLabel.TabIndex = 10;
            tournamentNameLabel.Text = "Tournament Name";
            // 
            // tournamentNameBox
            // 
            tournamentNameBox.Location = new Point(12, 109);
            tournamentNameBox.Name = "tournamentNameBox";
            tournamentNameBox.Size = new Size(240, 29);
            tournamentNameBox.TabIndex = 9;
            // 
            // entryFeeLabel
            // 
            entryFeeLabel.AutoSize = true;
            entryFeeLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            entryFeeLabel.ForeColor = SystemColors.GradientActiveCaption;
            entryFeeLabel.Location = new Point(12, 150);
            entryFeeLabel.Name = "entryFeeLabel";
            entryFeeLabel.Size = new Size(93, 25);
            entryFeeLabel.TabIndex = 12;
            entryFeeLabel.Text = "Entry Fee:";
            // 
            // entryFeeBox
            // 
            entryFeeBox.Location = new Point(161, 150);
            entryFeeBox.Name = "entryFeeBox";
            entryFeeBox.Size = new Size(91, 29);
            entryFeeBox.TabIndex = 11;
            entryFeeBox.Text = "0";
            // 
            // selectTeamComboBox
            // 
            selectTeamComboBox.FormattingEnabled = true;
            selectTeamComboBox.Location = new Point(12, 219);
            selectTeamComboBox.Name = "selectTeamComboBox";
            selectTeamComboBox.Size = new Size(240, 29);
            selectTeamComboBox.TabIndex = 14;
            // 
            // selectTeamLabel
            // 
            selectTeamLabel.AutoSize = true;
            selectTeamLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            selectTeamLabel.ForeColor = SystemColors.GradientActiveCaption;
            selectTeamLabel.Location = new Point(12, 191);
            selectTeamLabel.Name = "selectTeamLabel";
            selectTeamLabel.Size = new Size(111, 25);
            selectTeamLabel.TabIndex = 13;
            selectTeamLabel.Text = "Select Team";
            // 
            // createTeamLink
            // 
            createTeamLink.AutoSize = true;
            createTeamLink.Location = new Point(161, 194);
            createTeamLink.Name = "createTeamLink";
            createTeamLink.Size = new Size(91, 21);
            createTeamLink.TabIndex = 15;
            createTeamLink.TabStop = true;
            createTeamLink.Text = "Create New";
            createTeamLink.LinkClicked += createTeamLink_LinkClicked;
            // 
            // addTeamButton
            // 
            addTeamButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addTeamButton.ForeColor = Color.SteelBlue;
            addTeamButton.Location = new Point(28, 254);
            addTeamButton.Name = "addTeamButton";
            addTeamButton.Size = new Size(207, 30);
            addTeamButton.TabIndex = 16;
            addTeamButton.Text = "Add Team";
            addTeamButton.UseVisualStyleBackColor = true;
            addTeamButton.Click += addTeamButton_Click;
            // 
            // createPrizeButton
            // 
            createPrizeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            createPrizeButton.ForeColor = Color.SteelBlue;
            createPrizeButton.Location = new Point(323, 254);
            createPrizeButton.Name = "createPrizeButton";
            createPrizeButton.Size = new Size(207, 30);
            createPrizeButton.TabIndex = 17;
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = true;
            createPrizeButton.Click += createPrizeButton_Click;
            // 
            // tournamentTeamsListBox
            // 
            tournamentTeamsListBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentTeamsListBox.FormattingEnabled = true;
            tournamentTeamsListBox.ItemHeight = 20;
            tournamentTeamsListBox.Location = new Point(12, 324);
            tournamentTeamsListBox.Name = "tournamentTeamsListBox";
            tournamentTeamsListBox.Size = new Size(240, 104);
            tournamentTeamsListBox.TabIndex = 18;
            // 
            // tournamentTeamsLabel
            // 
            tournamentTeamsLabel.AutoSize = true;
            tournamentTeamsLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentTeamsLabel.ForeColor = SystemColors.GradientActiveCaption;
            tournamentTeamsLabel.Location = new Point(12, 296);
            tournamentTeamsLabel.Name = "tournamentTeamsLabel";
            tournamentTeamsLabel.Size = new Size(64, 25);
            tournamentTeamsLabel.TabIndex = 19;
            tournamentTeamsLabel.Text = "Teams";
            // 
            // tournamentPrizesLabel
            // 
            tournamentPrizesLabel.AutoSize = true;
            tournamentPrizesLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentPrizesLabel.ForeColor = SystemColors.GradientActiveCaption;
            tournamentPrizesLabel.Location = new Point(306, 296);
            tournamentPrizesLabel.Name = "tournamentPrizesLabel";
            tournamentPrizesLabel.Size = new Size(62, 25);
            tournamentPrizesLabel.TabIndex = 21;
            tournamentPrizesLabel.Text = "Prizes";
            // 
            // tournamentPrizesListBox
            // 
            tournamentPrizesListBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentPrizesListBox.FormattingEnabled = true;
            tournamentPrizesListBox.ItemHeight = 20;
            tournamentPrizesListBox.Location = new Point(306, 324);
            tournamentPrizesListBox.Name = "tournamentPrizesListBox";
            tournamentPrizesListBox.Size = new Size(240, 104);
            tournamentPrizesListBox.TabIndex = 20;
            // 
            // removeTeamLink
            // 
            removeTeamLink.AutoSize = true;
            removeTeamLink.Location = new Point(185, 299);
            removeTeamLink.Name = "removeTeamLink";
            removeTeamLink.Size = new Size(67, 21);
            removeTeamLink.TabIndex = 22;
            removeTeamLink.TabStop = true;
            removeTeamLink.Text = "Remove";
            removeTeamLink.LinkClicked += removeTeamLink_LinkClicked;
            // 
            // removePrizeLink
            // 
            removePrizeLink.AutoSize = true;
            removePrizeLink.Location = new Point(479, 299);
            removePrizeLink.Name = "removePrizeLink";
            removePrizeLink.Size = new Size(67, 21);
            removePrizeLink.TabIndex = 23;
            removePrizeLink.TabStop = true;
            removePrizeLink.Text = "Remove";
            removePrizeLink.LinkClicked += removePrizeLink_LinkClicked;
            // 
            // createTournamentButton
            // 
            createTournamentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            createTournamentButton.ForeColor = Color.SteelBlue;
            createTournamentButton.Location = new Point(306, 109);
            createTournamentButton.Name = "createTournamentButton";
            createTournamentButton.Size = new Size(240, 40);
            createTournamentButton.TabIndex = 24;
            createTournamentButton.Text = "Create Tournament";
            createTournamentButton.UseVisualStyleBackColor = true;
            createTournamentButton.Click += createTournamentButton_Click;
            // 
            // pictureArrowUp
            // 
            pictureArrowUp.Image = (Image)resources.GetObject("pictureArrowUp.Image");
            pictureArrowUp.Location = new Point(389, 177);
            pictureArrowUp.Name = "pictureArrowUp";
            pictureArrowUp.Size = new Size(72, 48);
            pictureArrowUp.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureArrowUp.TabIndex = 28;
            pictureArrowUp.TabStop = false;
            // 
            // TournamentCreator
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(560, 442);
            Controls.Add(pictureArrowUp);
            Controls.Add(createTournamentButton);
            Controls.Add(removePrizeLink);
            Controls.Add(removeTeamLink);
            Controls.Add(tournamentPrizesLabel);
            Controls.Add(tournamentPrizesListBox);
            Controls.Add(tournamentTeamsLabel);
            Controls.Add(tournamentTeamsListBox);
            Controls.Add(createPrizeButton);
            Controls.Add(addTeamButton);
            Controls.Add(createTeamLink);
            Controls.Add(selectTeamComboBox);
            Controls.Add(selectTeamLabel);
            Controls.Add(entryFeeLabel);
            Controls.Add(entryFeeBox);
            Controls.Add(tournamentNameLabel);
            Controls.Add(tournamentNameBox);
            Controls.Add(headerLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "TournamentCreator";
            Text = "Tournament Creator";
            ((System.ComponentModel.ISupportInitialize)pictureArrowUp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label tournamentNameLabel;
        private TextBox tournamentNameBox;
        private Label entryFeeLabel;
        private TextBox entryFeeBox;
        private ComboBox selectTeamComboBox;
        private Label selectTeamLabel;
        private LinkLabel createTeamLink;
        private Button addTeamButton;
        private Button createPrizeButton;
        private ListBox tournamentTeamsListBox;
        private Label tournamentTeamsLabel;
        private Label tournamentPrizesLabel;
        private ListBox tournamentPrizesListBox;
        private LinkLabel removeTeamLink;
        private LinkLabel removePrizeLink;
        private Button createTournamentButton;
        private PictureBox pictureArrowUp;
    }
}