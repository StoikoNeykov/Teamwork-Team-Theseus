namespace TheseusMainGame.UserControls
{
    using System.Windows.Forms;
    using System.Drawing.Text;

    using GameLogic;
   
    public partial class TopScores : Form
    {
        public TopScores()
        {
            InitializeComponent();


            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"D:\Teamwork\Team2\Teamwork-Team-Theseus\TeseusGame\adonais\Adonais.ttf");

            Back.Font = new System.Drawing.Font(pfc.Families[0], 25, System.Drawing.FontStyle.Regular);
        }

        private void TopScores_Load(object sender, System.EventArgs e)
        {
            var list = GameLogic.TopScores.Show();

            listBox.Items.AddRange(list);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var mainForm = (TheseusMainForm)Tag;
            mainForm.Show();
            Close();
        }
    }
}
