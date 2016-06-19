using System;
using System.Windows.Forms;

namespace TeseusMainGame
{
    static class Setup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TeseusMainForm());
        }
    }
}
