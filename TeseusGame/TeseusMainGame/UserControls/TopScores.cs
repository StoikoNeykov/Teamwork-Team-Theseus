namespace TheseusMainGame.UserControls
{
    using System.Windows.Forms;

    using GameLogic;
   
    public partial class TopScores : Form
    {
        public TopScores()
        {
            InitializeComponent();           
        }

        private void TopScores_Load(object sender, System.EventArgs e)
        {
            var list = GameLogic.TopScores.Show();

            listBox.Items.AddRange(list);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
