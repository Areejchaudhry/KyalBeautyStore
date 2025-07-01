using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_Project.ADMIN;

namespace VP_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            using (splahscreen splashscreen = new splahscreen())
            {
                splashscreen.ShowDialog();
            }






            Application.Run(new Choice());
        }
    }
}
