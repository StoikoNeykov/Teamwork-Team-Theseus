using TeseusMainGame.UserControls;

namespace TheseusMainGame
{
    using System;
    using System.Windows.Forms;
    using System.Drawing.Text;

    using UserControls;

    public partial class TheseusMainForm : Form
    {

        
        public TheseusMainForm()
        {
           
            InitializeComponent();
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"../../Font/Adonais.ttf");

            button1.Font = new System.Drawing.Font(pfc.Families[0], 25, System.Drawing.FontStyle.Regular);
            button2.Font = new System.Drawing.Font(pfc.Families[0], 25, System.Drawing.FontStyle.Regular);
            button3.Font = new System.Drawing.Font(pfc.Families[0], 25, System.Drawing.FontStyle.Regular);
            button4.Font = new System.Drawing.Font(pfc.Families[0], 25, System.Drawing.FontStyle.Regular);



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

        private void button1_Click(object sender, EventArgs e)
        {
            var play = new Play();
            play.Tag = this;
            play.Show(this);
          

        }
    }
}
