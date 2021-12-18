using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer;
using DataAccessLayer;

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

            OFCcountry screen = new OFCcountry();
            IDatabaseCreateQueries create = new DatabaseCreateQueries();
            IDatabaseReadQueries read = new DatabaseReadQueries();
            ICustomerModel model = new CustomerModel(create, read);
            IEnquiryModel enq = new EnquiryModel(create);

            Presentation presentation = new Presentation(model, screen, enq);

            Application.Run(screen);
        }
    }
}
