using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer;

namespace PresentationLayer
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

            Enquiry enquiry = new Enquiry(DateTime.Now, DateTime.Now.AddDays(1));

            /* Used to test the check if the data will be saved to the database

            Enquiry enquiry = new Enquiry(DateTime.Now, DateTime.Now.AddDays(1));
            enquiry.createSword("Sword", 5, null);
            enquiry.createArmour("Armour", 2, null);
            enquiry.createCeremonialSword("CeremonialSword", 3, null);

            DatabaseCreateQueries create = new DatabaseCreateQueries();
            bool value = create.SaveEnquiry(enquiry);
            System.Windows.Forms.MessageBox.Show(value.ToString());

            */
        }
    }
}
