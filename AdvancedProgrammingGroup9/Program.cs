using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedProgrammingGroup9
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OrderCust());

            Enquiry enquiry = new Enquiry(1, DateTime.Now, DateTime.Now.AddDays(1));
            enquiry.createSword("Sword1", 1, null);
            enquiry.createArmour("Sword2", 1, null);
        }

    }
}
