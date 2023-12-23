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
            emailGroupBox = new GroupBox();
            portBox = new TextBox();
            portLabel = new Label();
            saveEmailButton = new Button();
            hostBox = new TextBox();
            hostLabel = new Label();
            passwordBox = new TextBox();
            passwordLabel = new Label();
            emailBox = new TextBox();
            emailLabel = new Label();
            fromNameBox = new TextBox();
            fromNameLabel = new Label();
            emailGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel.ForeColor = SystemColors.GradientActiveCaption;
            headerLabel.Location = new Point(90, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(353, 45);
            headerLabel.TabIndex = 30;
            headerLabel.Text = "Tournament Dashboard";
            // 
            // loadTournamentComboBox
            // 
            loadTournamentComboBox.FormattingEnabled = true;
            loadTournamentComboBox.Location = new Point(280, 113);
            loadTournamentComboBox.Name = "loadTournamentComboBox";
            loadTournamentComboBox.Size = new Size(240, 29);
            loadTournamentComboBox.TabIndex = 32;
            // 
            // loadTournamentLabel
            // 
            loadTournamentLabel.AutoSize = true;
            loadTournamentLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            loadTournamentLabel.ForeColor = SystemColors.GradientActiveCaption;
            loadTournamentLabel.Location = new Point(301, 80);
            loadTournamentLabel.Name = "loadTournamentLabel";
            loadTournamentLabel.Size = new Size(210, 30);
            loadTournamentLabel.TabIndex = 31;
            loadTournamentLabel.Text = "Existing Tournaments";
            // 
            // loadTournamentButton
            // 
            loadTournamentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            loadTournamentButton.ForeColor = Color.SteelBlue;
            loadTournamentButton.Location = new Point(280, 148);
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
            createTournamentButton.Location = new Point(280, 280);
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
            refreshTournamentsButton.Location = new Point(280, 194);
            refreshTournamentsButton.Name = "refreshTournamentsButton";
            refreshTournamentsButton.Size = new Size(240, 29);
            refreshTournamentsButton.TabIndex = 35;
            refreshTournamentsButton.Text = "Refresh List";
            refreshTournamentsButton.UseVisualStyleBackColor = true;
            refreshTournamentsButton.Click += refreshTournamentsButton_Click;
            // 
            // emailGroupBox
            // 
            emailGroupBox.Controls.Add(portBox);
            emailGroupBox.Controls.Add(portLabel);
            emailGroupBox.Controls.Add(saveEmailButton);
            emailGroupBox.Controls.Add(hostBox);
            emailGroupBox.Controls.Add(hostLabel);
            emailGroupBox.Controls.Add(passwordBox);
            emailGroupBox.Controls.Add(passwordLabel);
            emailGroupBox.Controls.Add(emailBox);
            emailGroupBox.Controls.Add(emailLabel);
            emailGroupBox.Controls.Add(fromNameBox);
            emailGroupBox.Controls.Add(fromNameLabel);
            emailGroupBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            emailGroupBox.ForeColor = SystemColors.GradientActiveCaption;
            emailGroupBox.Location = new Point(12, 80);
            emailGroupBox.Name = "emailGroupBox";
            emailGroupBox.Size = new Size(240, 240);
            emailGroupBox.TabIndex = 36;
            emailGroupBox.TabStop = false;
            emailGroupBox.Text = "Email settings";
            // 
            // portBox
            // 
            portBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            portBox.Location = new Point(98, 168);
            portBox.Name = "portBox";
            portBox.Size = new Size(126, 29);
            portBox.TabIndex = 23;
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            portLabel.ForeColor = SystemColors.GradientActiveCaption;
            portLabel.Location = new Point(6, 171);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(82, 21);
            portLabel.TabIndex = 22;
            portLabel.Text = "SMTP Port";
            // 
            // saveEmailButton
            // 
            saveEmailButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            saveEmailButton.ForeColor = Color.SteelBlue;
            saveEmailButton.Location = new Point(17, 203);
            saveEmailButton.Name = "saveEmailButton";
            saveEmailButton.Size = new Size(207, 30);
            saveEmailButton.TabIndex = 21;
            saveEmailButton.Text = "Save Email";
            saveEmailButton.UseVisualStyleBackColor = true;
            saveEmailButton.Click += saveEmailButton_Click;
            // 
            // hostBox
            // 
            hostBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            hostBox.Location = new Point(98, 133);
            hostBox.Name = "hostBox";
            hostBox.Size = new Size(126, 29);
            hostBox.TabIndex = 13;
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            hostLabel.ForeColor = SystemColors.GradientActiveCaption;
            hostLabel.Location = new Point(6, 136);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(91, 21);
            hostLabel.TabIndex = 12;
            hostLabel.Text = "Host Server";
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordBox.Location = new Point(98, 98);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(126, 29);
            passwordBox.TabIndex = 11;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordLabel.ForeColor = SystemColors.GradientActiveCaption;
            passwordLabel.Location = new Point(6, 101);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(76, 21);
            passwordLabel.TabIndex = 10;
            passwordLabel.Text = "Password";
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailBox.Location = new Point(98, 63);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(126, 29);
            emailBox.TabIndex = 9;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.ForeColor = SystemColors.GradientActiveCaption;
            emailLabel.Location = new Point(6, 66);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(48, 21);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "Email";
            // 
            // fromNameBox
            // 
            fromNameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fromNameBox.Location = new Point(98, 28);
            fromNameBox.Name = "fromNameBox";
            fromNameBox.Size = new Size(126, 29);
            fromNameBox.TabIndex = 7;
            // 
            // fromNameLabel
            // 
            fromNameLabel.AutoSize = true;
            fromNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fromNameLabel.ForeColor = SystemColors.GradientActiveCaption;
            fromNameLabel.Location = new Point(6, 31);
            fromNameLabel.Name = "fromNameLabel";
            fromNameLabel.Size = new Size(93, 21);
            fromNameLabel.TabIndex = 6;
            fromNameLabel.Text = "From Name";
            // 
            // TournamentDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(532, 337);
            Controls.Add(emailGroupBox);
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
            emailGroupBox.ResumeLayout(false);
            emailGroupBox.PerformLayout();
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
        private GroupBox emailGroupBox;
        private Button saveEmailButton;
        private TextBox hostBox;
        private Label hostLabel;
        private TextBox passwordBox;
        private Label passwordLabel;
        private TextBox emailBox;
        private Label emailLabel;
        private TextBox fromNameBox;
        private Label fromNameLabel;
        private TextBox portBox;
        private Label portLabel;
    }
}