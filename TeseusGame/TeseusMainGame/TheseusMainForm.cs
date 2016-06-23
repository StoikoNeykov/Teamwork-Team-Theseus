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
            topScores.Tag = this;
            topScores.Show(this);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var howToPlay = new HowToPlay();
            howToPlay.Tag = this;
            howToPlay.Show(this);
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var credits = new Credits();
            credits.Tag = this;
            credits.Show(this);
            Hide();
        }
    }
}
