namespace TheseusMainGame.UserControls
{
    using System.Windows.Forms;

    public partial class HowToPlay : Form
    {
        public HowToPlay()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, System.EventArgs e)
        {
            var mainForm = (TheseusMainForm)Tag;
            mainForm.Show();
            Close();
        }
    }
}
