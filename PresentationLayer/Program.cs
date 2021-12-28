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

            IEnquiryGateway enquiryGateway = new EnquiryGateway();
            IOrderItemGateway orderItemGateway = new OrderItemGateway();
            ICustomerGateway customerGateway = new CustomerGateway();

            IEnquiryModel enq = new EnquiryModel(enquiryGateway, orderItemGateway, customerGateway);

            EnquiryPresenter presentation = new EnquiryPresenter(screen, enq);

            Application.Run(screen);
        }
    }
}
