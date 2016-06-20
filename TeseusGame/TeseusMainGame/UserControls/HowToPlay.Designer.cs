namespace TheseusMainGame.UserControls
{
    partial class HowToPlay
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
            this.HowToPlayTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // HowToPlayTextBox
            // 
            this.HowToPlayTextBox.Location = new System.Drawing.Point(49, 129);
            this.HowToPlayTextBox.Name = "HowToPlayTextBox";
            this.HowToPlayTextBox.Size = new System.Drawing.Size(298, 330);
            this.HowToPlayTextBox.TabIndex = 0;
            this.HowToPlayTextBox.Text = "";
            // 
            // HowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 522);
            this.Controls.Add(this.HowToPlayTextBox);
            this.Name = "HowToPlay";
            this.Text = "HowToPlay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox HowToPlayTextBox;
    }
}