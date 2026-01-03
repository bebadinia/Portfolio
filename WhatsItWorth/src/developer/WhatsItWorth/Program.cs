// Program.cs by Ben Ebadinia

using System;
using System.Windows.Forms;

namespace WhatsItWorth
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            // Initialize WinForms application settings.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run the login page as the entry point.
            Application.Run(new LogInPage());
        }
    }
}
