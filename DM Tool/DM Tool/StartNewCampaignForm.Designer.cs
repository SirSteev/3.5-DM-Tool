namespace DM_Tool
{
    partial class StartNewCampaignForm
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
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.nudDay = new System.Windows.Forms.NumericUpDown();
            this.nudMonth = new System.Windows.Forms.NumericUpDown();
            this.btnSetDate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSeasonalYear = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSeasonalSetDate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCampaignName = new System.Windows.Forms.TextBox();
            this.cbSeasonalFestivals = new System.Windows.Forms.ComboBox();
            this.lbPlayerList = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.nudPlayerMaxHP = new System.Windows.Forms.NumericUpDown();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.btnRemovePlayer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeasonalYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayerMaxHP)).BeginInit();
            this.SuspendLayout();
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(103, 201);
            this.nudYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(46, 20);
            this.nudYear.TabIndex = 42;
            this.nudYear.Value = new decimal(new int[] {
            1380,
            0,
            0,
            0});
            // 
            // nudDay
            // 
            this.nudDay.Location = new System.Drawing.Point(58, 201);
            this.nudDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDay.Name = "nudDay";
            this.nudDay.Size = new System.Drawing.Size(39, 20);
            this.nudDay.TabIndex = 41;
            this.nudDay.Value = new decimal(new int[] {
            19,
            0,
            0,
            0});
            // 
            // nudMonth
            // 
            this.nudMonth.Location = new System.Drawing.Point(15, 201);
            this.nudMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMonth.Name = "nudMonth";
            this.nudMonth.Size = new System.Drawing.Size(37, 20);
            this.nudMonth.TabIndex = 40;
            this.nudMonth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // btnSetDate
            // 
            this.btnSetDate.Location = new System.Drawing.Point(15, 227);
            this.btnSetDate.Name = "btnSetDate";
            this.btnSetDate.Size = new System.Drawing.Size(134, 20);
            this.btnSetDate.TabIndex = 39;
            this.btnSetDate.Text = "Set Date";
            this.btnSetDate.UseVisualStyleBackColor = true;
            this.btnSetDate.Click += new System.EventHandler(this.btnSetDate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Day";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "or";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Year";
            // 
            // nudSeasonalYear
            // 
            this.nudSeasonalYear.Location = new System.Drawing.Point(303, 201);
            this.nudSeasonalYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudSeasonalYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSeasonalYear.Name = "nudSeasonalYear";
            this.nudSeasonalYear.Size = new System.Drawing.Size(46, 20);
            this.nudSeasonalYear.TabIndex = 48;
            this.nudSeasonalYear.Value = new decimal(new int[] {
            1380,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Seasonal Festival";
            // 
            // btnSeasonalSetDate
            // 
            this.btnSeasonalSetDate.Location = new System.Drawing.Point(177, 227);
            this.btnSeasonalSetDate.Name = "btnSeasonalSetDate";
            this.btnSeasonalSetDate.Size = new System.Drawing.Size(172, 20);
            this.btnSeasonalSetDate.TabIndex = 51;
            this.btnSeasonalSetDate.Text = "Set Date";
            this.btnSeasonalSetDate.UseVisualStyleBackColor = true;
            this.btnSeasonalSetDate.Click += new System.EventHandler(this.btnSeasonalSetDate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Campaign Name";
            // 
            // tbCampaignName
            // 
            this.tbCampaignName.Location = new System.Drawing.Point(15, 26);
            this.tbCampaignName.Name = "tbCampaignName";
            this.tbCampaignName.Size = new System.Drawing.Size(334, 20);
            this.tbCampaignName.TabIndex = 53;
            // 
            // cbSeasonalFestivals
            // 
            this.cbSeasonalFestivals.FormattingEnabled = true;
            this.cbSeasonalFestivals.Location = new System.Drawing.Point(177, 201);
            this.cbSeasonalFestivals.Name = "cbSeasonalFestivals";
            this.cbSeasonalFestivals.Size = new System.Drawing.Size(121, 21);
            this.cbSeasonalFestivals.TabIndex = 54;
            // 
            // lbPlayerList
            // 
            this.lbPlayerList.FormattingEnabled = true;
            this.lbPlayerList.Location = new System.Drawing.Point(15, 65);
            this.lbPlayerList.Name = "lbPlayerList";
            this.lbPlayerList.Size = new System.Drawing.Size(120, 108);
            this.lbPlayerList.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Players";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Player Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(244, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Max HP";
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Location = new System.Drawing.Point(141, 65);
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.Size = new System.Drawing.Size(100, 20);
            this.tbPlayerName.TabIndex = 59;
            // 
            // nudPlayerMaxHP
            // 
            this.nudPlayerMaxHP.Location = new System.Drawing.Point(247, 66);
            this.nudPlayerMaxHP.Name = "nudPlayerMaxHP";
            this.nudPlayerMaxHP.Size = new System.Drawing.Size(102, 20);
            this.nudPlayerMaxHP.TabIndex = 60;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnAddPlayer.Location = new System.Drawing.Point(141, 91);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(208, 40);
            this.btnAddPlayer.TabIndex = 61;
            this.btnAddPlayer.Text = "Add Player";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // btnRemovePlayer
            // 
            this.btnRemovePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnRemovePlayer.Location = new System.Drawing.Point(141, 137);
            this.btnRemovePlayer.Name = "btnRemovePlayer";
            this.btnRemovePlayer.Size = new System.Drawing.Size(208, 40);
            this.btnRemovePlayer.TabIndex = 62;
            this.btnRemovePlayer.Text = "Remove Player";
            this.btnRemovePlayer.UseVisualStyleBackColor = true;
            this.btnRemovePlayer.Click += new System.EventHandler(this.btnRemovePlayer_Click);
            // 
            // StartNewCampaignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 263);
            this.Controls.Add(this.btnRemovePlayer);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.nudPlayerMaxHP);
            this.Controls.Add(this.tbPlayerName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbPlayerList);
            this.Controls.Add(this.cbSeasonalFestivals);
            this.Controls.Add(this.tbCampaignName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSeasonalSetDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudSeasonalYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.nudDay);
            this.Controls.Add(this.nudMonth);
            this.Controls.Add(this.btnSetDate);
            this.Name = "StartNewCampaignForm";
            this.Text = "Start New Campaign";
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeasonalYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayerMaxHP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.NumericUpDown nudDay;
        private System.Windows.Forms.NumericUpDown nudMonth;
        private System.Windows.Forms.Button btnSetDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSeasonalYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSeasonalSetDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCampaignName;
        private System.Windows.Forms.ComboBox cbSeasonalFestivals;
        private System.Windows.Forms.ListBox lbPlayerList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPlayerName;
        private System.Windows.Forms.NumericUpDown nudPlayerMaxHP;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnRemovePlayer;
    }
}