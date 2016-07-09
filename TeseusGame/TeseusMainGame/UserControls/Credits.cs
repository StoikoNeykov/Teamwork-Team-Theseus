namespace TheseusMainGame.UserControls
{
    using System.Drawing.Text;
    using System;
    using System.Windows.Forms;

    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"..\..\Font\Adonais.ttf");

            Back.Font = new System.Drawing.Font(pfc.Families[0], 25, System.Drawing.FontStyle.Regular);
            label8.Font = new System.Drawing.Font(pfc.Families[0], 25, System.Drawing.FontStyle.Regular);




        }

        private void Close_Click(object sender, EventArgs e)
        {
            var mainForm = (TheseusMainForm)Tag;
            mainForm.Show();
            Close();
        }
    }
}
