namespace TheseusMainGame
{
    using System;
    using System.Windows.Forms;

    using UserControls;

    public partial class TheseusMainForm : Form
    {
        public TheseusMainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var topScores = new TopScores();
            topScores.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var howToPlay = new HowToPlay();
            howToPlay.Show();
        }
    }
}
