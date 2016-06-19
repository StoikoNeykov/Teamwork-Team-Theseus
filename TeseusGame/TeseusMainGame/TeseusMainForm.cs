namespace TeseusMainGame
{
    using System;
    using System.Windows.Forms;

    using UserControls;

    public partial class TeseusMainForm : Form
    {
        public TeseusMainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var topScores = new TopScores();
            topScores.Show();
        }
    }
}
