namespace TrackerUI
{
    partial class TournamentViewer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentViewer));
            teamOneScoreLabel = new Label();
            headerLabel = new Label();
            nameLabel = new Label();
            roundLabel = new Label();
            roundComboBox = new ComboBox();
            teamOneScoreBox = new TextBox();
            roundCheckBox = new CheckBox();
            matchupListBox = new ListBox();
            teamOneLabel = new Label();
            vsLabel = new Label();
            teamTwoLabel = new Label();
            teamTwoScoreBox = new TextBox();
            teamTwoScoreLabel = new Label();
            playButton = new Button();
            SuspendLayout();
            // 
            // teamOneScoreLabel
            // 
            teamOneScoreLabel.AutoSize = true;
            teamOneScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamOneScoreLabel.ForeColor = SystemColors.GradientActiveCaption;
            teamOneScoreLabel.Location = new Point(313, 182);
            teamOneScoreLabel.Name = "teamOneScoreLabel";
            teamOneScoreLabel.Size = new Size(49, 21);
            teamOneScoreLabel.TabIndex = 0;
            teamOneScoreLabel.Text = "Score";
            teamOneScoreLabel.Click += label1_Click;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel.ForeColor = SystemColors.GradientActiveCaption;
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(197, 45);
            headerLabel.TabIndex = 1;
            headerLabel.Text = "Tournament:";
            headerLabel.Click += label2_Click;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.ForeColor = SystemColors.GradientActiveCaption;
            nameLabel.Location = new Point(215, 9);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(136, 45);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "<none>";
            // 
            // roundLabel
            // 
            roundLabel.AutoSize = true;
            roundLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            roundLabel.ForeColor = SystemColors.GradientActiveCaption;
            roundLabel.Location = new Point(12, 76);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(73, 30);
            roundLabel.TabIndex = 3;
            roundLabel.Text = "Round";
            // 
            // roundComboBox
            // 
            roundComboBox.FormattingEnabled = true;
            roundComboBox.Location = new Point(91, 80);
            roundComboBox.Name = "roundComboBox";
            roundComboBox.Size = new Size(161, 29);
            roundComboBox.TabIndex = 4;
            // 
            // teamOneScoreBox
            // 
            teamOneScoreBox.Location = new Point(371, 179);
            teamOneScoreBox.Name = "teamOneScoreBox";
            teamOneScoreBox.Size = new Size(100, 29);
            teamOneScoreBox.TabIndex = 5;
            teamOneScoreBox.TextChanged += textBox1_TextChanged;
            // 
            // roundCheckBox
            // 
            roundCheckBox.AutoSize = true;
            roundCheckBox.ForeColor = SystemColors.GradientActiveCaption;
            roundCheckBox.Location = new Point(91, 115);
            roundCheckBox.Name = "roundCheckBox";
            roundCheckBox.Size = new Size(132, 25);
            roundCheckBox.TabIndex = 6;
            roundCheckBox.Text = "Unplayed Only";
            roundCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchupListBox
            // 
            matchupListBox.FormattingEnabled = true;
            matchupListBox.ItemHeight = 21;
            matchupListBox.Location = new Point(12, 146);
            matchupListBox.Name = "matchupListBox";
            matchupListBox.Size = new Size(240, 193);
            matchupListBox.TabIndex = 7;
            // 
            // teamOneLabel
            // 
            teamOneLabel.AutoSize = true;
            teamOneLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            teamOneLabel.ForeColor = SystemColors.GradientActiveCaption;
            teamOneLabel.Location = new Point(301, 146);
            teamOneLabel.Name = "teamOneLabel";
            teamOneLabel.Size = new Size(129, 30);
            teamOneLabel.TabIndex = 8;
            teamOneLabel.Text = "<team one>";
            // 
            // vsLabel
            // 
            vsLabel.AutoSize = true;
            vsLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            vsLabel.ForeColor = SystemColors.GradientActiveCaption;
            vsLabel.Location = new Point(312, 232);
            vsLabel.Name = "vsLabel";
            vsLabel.Size = new Size(50, 25);
            vsLabel.TabIndex = 9;
            vsLabel.Text = "-VS-";
            // 
            // teamTwoLabel
            // 
            teamTwoLabel.AutoSize = true;
            teamTwoLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            teamTwoLabel.ForeColor = SystemColors.GradientActiveCaption;
            teamTwoLabel.Location = new Point(301, 268);
            teamTwoLabel.Name = "teamTwoLabel";
            teamTwoLabel.Size = new Size(129, 30);
            teamTwoLabel.TabIndex = 12;
            teamTwoLabel.Text = "<team one>";
            // 
            // teamTwoScoreBox
            // 
            teamTwoScoreBox.Location = new Point(371, 301);
            teamTwoScoreBox.Name = "teamTwoScoreBox";
            teamTwoScoreBox.Size = new Size(100, 29);
            teamTwoScoreBox.TabIndex = 11;
            // 
            // teamTwoScoreLabel
            // 
            teamTwoScoreLabel.AutoSize = true;
            teamTwoScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamTwoScoreLabel.ForeColor = SystemColors.GradientActiveCaption;
            teamTwoScoreLabel.Location = new Point(313, 304);
            teamTwoScoreLabel.Name = "teamTwoScoreLabel";
            teamTwoScoreLabel.Size = new Size(49, 21);
            teamTwoScoreLabel.TabIndex = 10;
            teamTwoScoreLabel.Text = "Score";
            // 
            // playButton
            // 
            playButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            playButton.ForeColor = Color.SteelBlue;
            playButton.Location = new Point(371, 230);
            playButton.Name = "playButton";
            playButton.Size = new Size(100, 30);
            playButton.TabIndex = 13;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            // 
            // TournamentViewer
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(486, 351);
            Controls.Add(playButton);
            Controls.Add(teamTwoLabel);
            Controls.Add(teamTwoScoreBox);
            Controls.Add(teamTwoScoreLabel);
            Controls.Add(vsLabel);
            Controls.Add(teamOneLabel);
            Controls.Add(matchupListBox);
            Controls.Add(roundCheckBox);
            Controls.Add(teamOneScoreBox);
            Controls.Add(roundComboBox);
            Controls.Add(roundLabel);
            Controls.Add(nameLabel);
            Controls.Add(headerLabel);
            Controls.Add(teamOneScoreLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "TournamentViewer";
            Text = "Tournament Viewer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label teamOneScoreLabel;
        private Label headerLabel;
        private Label nameLabel;
        private Label roundLabel;
        private ComboBox roundComboBox;
        private TextBox teamOneScoreBox;
        private CheckBox roundCheckBox;
        private ListBox matchupListBox;
        private Label teamOneLabel;
        private Label vsLabel;
        private Label teamTwoLabel;
        private TextBox teamTwoScoreBox;
        private Label teamTwoScoreLabel;
        private Button playButton;
    }
}