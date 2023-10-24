namespace TrackerUI
{
    partial class TournamentDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentDashboard));
            headerLabel = new Label();
            loadTournamentComboBox = new ComboBox();
            loadTournamentLabel = new Label();
            loadTournamentButton = new Button();
            createTournamentButton = new Button();
            refreshTournamentsButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel.ForeColor = SystemColors.GradientActiveCaption;
            headerLabel.Location = new Point(116, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(353, 45);
            headerLabel.TabIndex = 30;
            headerLabel.Text = "Tournament Dashboard";
            // 
            // loadTournamentComboBox
            // 
            loadTournamentComboBox.FormattingEnabled = true;
            loadTournamentComboBox.Location = new Point(172, 109);
            loadTournamentComboBox.Name = "loadTournamentComboBox";
            loadTournamentComboBox.Size = new Size(240, 29);
            loadTournamentComboBox.TabIndex = 32;
            // 
            // loadTournamentLabel
            // 
            loadTournamentLabel.AutoSize = true;
            loadTournamentLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            loadTournamentLabel.ForeColor = SystemColors.GradientActiveCaption;
            loadTournamentLabel.Location = new Point(187, 76);
            loadTournamentLabel.Name = "loadTournamentLabel";
            loadTournamentLabel.Size = new Size(210, 30);
            loadTournamentLabel.TabIndex = 31;
            loadTournamentLabel.Text = "Existing Tournaments";
            // 
            // loadTournamentButton
            // 
            loadTournamentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            loadTournamentButton.ForeColor = Color.SteelBlue;
            loadTournamentButton.Location = new Point(172, 144);
            loadTournamentButton.Name = "loadTournamentButton";
            loadTournamentButton.Size = new Size(240, 40);
            loadTournamentButton.TabIndex = 33;
            loadTournamentButton.Text = "Load Tournament";
            loadTournamentButton.UseVisualStyleBackColor = true;
            loadTournamentButton.Click += loadTournamentButton_Click;
            // 
            // createTournamentButton
            // 
            createTournamentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            createTournamentButton.ForeColor = Color.SteelBlue;
            createTournamentButton.Location = new Point(172, 216);
            createTournamentButton.Name = "createTournamentButton";
            createTournamentButton.Size = new Size(240, 40);
            createTournamentButton.TabIndex = 34;
            createTournamentButton.Text = "Create Tournament";
            createTournamentButton.UseVisualStyleBackColor = true;
            createTournamentButton.Click += createTournamentButton_Click;
            // 
            // refreshTournamentsButton
            // 
            refreshTournamentsButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            refreshTournamentsButton.ForeColor = Color.SteelBlue;
            refreshTournamentsButton.Location = new Point(427, 109);
            refreshTournamentsButton.Name = "refreshTournamentsButton";
            refreshTournamentsButton.Size = new Size(120, 29);
            refreshTournamentsButton.TabIndex = 35;
            refreshTournamentsButton.Text = "Refresh";
            refreshTournamentsButton.UseVisualStyleBackColor = true;
            refreshTournamentsButton.Click += refreshTournamentsButton_Click;
            // 
            // TournamentDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(584, 280);
            Controls.Add(refreshTournamentsButton);
            Controls.Add(createTournamentButton);
            Controls.Add(loadTournamentButton);
            Controls.Add(loadTournamentComboBox);
            Controls.Add(loadTournamentLabel);
            Controls.Add(headerLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "TournamentDashboard";
            Text = "Tournament Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private ComboBox loadTournamentComboBox;
        private Label loadTournamentLabel;
        private Button loadTournamentButton;
        private Button createTournamentButton;
        private Button refreshTournamentsButton;
    }
}