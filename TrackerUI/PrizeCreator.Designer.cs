namespace TrackerUI
{
    partial class PrizeCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrizeCreator));
            orLabel = new Label();
            createPrizeButton = new Button();
            prizePercentageLabel = new Label();
            prizePercentageBox = new TextBox();
            prizeAmountLabel = new Label();
            prizeAmountBox = new TextBox();
            placeNameLabel = new Label();
            placeNameBox = new TextBox();
            placeNumberLabel = new Label();
            placeNumberBox = new TextBox();
            headerLabel = new Label();
            SuspendLayout();
            // 
            // orLabel
            // 
            orLabel.AutoSize = true;
            orLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            orLabel.ForeColor = SystemColors.GradientActiveCaption;
            orLabel.Location = new Point(171, 211);
            orLabel.Name = "orLabel";
            orLabel.Size = new Size(46, 25);
            orLabel.TabIndex = 39;
            orLabel.Text = "-or-";
            // 
            // createPrizeButton
            // 
            createPrizeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            createPrizeButton.ForeColor = Color.SteelBlue;
            createPrizeButton.Location = new Point(55, 304);
            createPrizeButton.Name = "createPrizeButton";
            createPrizeButton.Size = new Size(240, 40);
            createPrizeButton.TabIndex = 38;
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = true;
            createPrizeButton.Click += createPrizeButton_Click;
            // 
            // prizePercentageLabel
            // 
            prizePercentageLabel.AutoSize = true;
            prizePercentageLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            prizePercentageLabel.ForeColor = SystemColors.GradientActiveCaption;
            prizePercentageLabel.Location = new Point(12, 248);
            prizePercentageLabel.Name = "prizePercentageLabel";
            prizePercentageLabel.Size = new Size(153, 25);
            prizePercentageLabel.TabIndex = 37;
            prizePercentageLabel.Text = "Prize Percentage";
            // 
            // prizePercentageBox
            // 
            prizePercentageBox.Location = new Point(171, 248);
            prizePercentageBox.Name = "prizePercentageBox";
            prizePercentageBox.Size = new Size(167, 29);
            prizePercentageBox.TabIndex = 36;
            // 
            // prizeAmountLabel
            // 
            prizeAmountLabel.AutoSize = true;
            prizeAmountLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            prizeAmountLabel.ForeColor = SystemColors.GradientActiveCaption;
            prizeAmountLabel.Location = new Point(12, 170);
            prizeAmountLabel.Name = "prizeAmountLabel";
            prizeAmountLabel.Size = new Size(126, 25);
            prizeAmountLabel.TabIndex = 35;
            prizeAmountLabel.Text = "Prize Amount";
            // 
            // prizeAmountBox
            // 
            prizeAmountBox.Location = new Point(171, 170);
            prizeAmountBox.Name = "prizeAmountBox";
            prizeAmountBox.Size = new Size(167, 29);
            prizeAmountBox.TabIndex = 34;
            // 
            // placeNameLabel
            // 
            placeNameLabel.AutoSize = true;
            placeNameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            placeNameLabel.ForeColor = SystemColors.GradientActiveCaption;
            placeNameLabel.Location = new Point(12, 114);
            placeNameLabel.Name = "placeNameLabel";
            placeNameLabel.Size = new Size(112, 25);
            placeNameLabel.TabIndex = 33;
            placeNameLabel.Text = "Place Name";
            // 
            // placeNameBox
            // 
            placeNameBox.Location = new Point(171, 114);
            placeNameBox.Name = "placeNameBox";
            placeNameBox.Size = new Size(167, 29);
            placeNameBox.TabIndex = 32;
            // 
            // placeNumberLabel
            // 
            placeNumberLabel.AutoSize = true;
            placeNumberLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            placeNumberLabel.ForeColor = SystemColors.GradientActiveCaption;
            placeNumberLabel.Location = new Point(12, 79);
            placeNumberLabel.Name = "placeNumberLabel";
            placeNumberLabel.Size = new Size(131, 25);
            placeNumberLabel.TabIndex = 31;
            placeNumberLabel.Text = "Place Number";
            // 
            // placeNumberBox
            // 
            placeNumberBox.Location = new Point(171, 79);
            placeNumberBox.Name = "placeNumberBox";
            placeNumberBox.Size = new Size(167, 29);
            placeNumberBox.TabIndex = 30;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel.ForeColor = SystemColors.GradientActiveCaption;
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(202, 45);
            headerLabel.TabIndex = 29;
            headerLabel.Text = "Prize Creator";
            // 
            // PrizeCreator
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(353, 358);
            Controls.Add(orLabel);
            Controls.Add(createPrizeButton);
            Controls.Add(prizePercentageLabel);
            Controls.Add(prizePercentageBox);
            Controls.Add(prizeAmountLabel);
            Controls.Add(prizeAmountBox);
            Controls.Add(placeNameLabel);
            Controls.Add(placeNameBox);
            Controls.Add(placeNumberLabel);
            Controls.Add(placeNumberBox);
            Controls.Add(headerLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "PrizeCreator";
            Text = "PrizeCreator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label orLabel;
        private Button createPrizeButton;
        private Label prizePercentageLabel;
        private TextBox prizePercentageBox;
        private Label prizeAmountLabel;
        private TextBox prizeAmountBox;
        private Label placeNameLabel;
        private TextBox placeNameBox;
        private Label placeNumberLabel;
        private TextBox placeNumberBox;
        private Label headerLabel;
    }
}