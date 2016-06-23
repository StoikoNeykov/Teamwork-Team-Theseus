namespace TheseusMainGame.UserControls
{
    using System;
    using System.Windows.Forms;

    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            var mainForm = (TheseusMainForm)Tag;
            mainForm.Show();
            Close();
        }
    }
}
