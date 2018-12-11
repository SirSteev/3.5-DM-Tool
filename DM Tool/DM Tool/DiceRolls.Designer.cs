namespace DM_Tool
{
    partial class DiceRolls
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
            this.tbDiceBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbDiceBox
            // 
            this.tbDiceBox.Location = new System.Drawing.Point(12, 12);
            this.tbDiceBox.Multiline = true;
            this.tbDiceBox.Name = "tbDiceBox";
            this.tbDiceBox.ReadOnly = true;
            this.tbDiceBox.Size = new System.Drawing.Size(521, 448);
            this.tbDiceBox.TabIndex = 19;
            // 
            // DiceRolls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 472);
            this.Controls.Add(this.tbDiceBox);
            this.Name = "DiceRolls";
            this.Text = "DiceRolls";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDiceBox;
    }
}