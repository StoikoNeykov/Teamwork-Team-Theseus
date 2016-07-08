namespace TheseusMainGame.UserControls
{
    using System.Windows.Forms;
    using System.Drawing.Text;

    public partial class HowToPlay : Form
    {
        public HowToPlay()
        {
            InitializeComponent();

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"D:\Teamwork\Team2\Teamwork-Team-Theseus\TeseusGame\adonais\Adonais.ttf");

            Back.Font = new System.Drawing.Font(pfc.Families[0], 25, System.Drawing.FontStyle.Regular);
            
        }

        private void Close_Click(object sender, System.EventArgs e)
        {
            var mainForm = (TheseusMainForm)Tag;
            mainForm.Show();
            Close();
        }
    }
}
