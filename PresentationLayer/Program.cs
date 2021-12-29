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

            
            IEnquiryGateway enquiryGateway = new EnquiryGateway();
            IOrderItemGateway orderItemGateway = new OrderItemGateway();
            ICustomerGateway customerGateway = new CustomerGateway();
            IOrderGateway orderGateway = new OrderGateway();


            //OFCcountry screen = new OFCcountry();
            MainForm screen = new MainForm();

            /*
            IEnquiryModel enq = new EnquiryModel(enquiryGateway, orderItemGateway, customerGateway);
            EnquiryPresenter presentation = new EnquiryPresenter(screen, enq);
            
            IManagerModel manager = new ManagerModel(enquiryGateway, customerGateway, orderItemGateway, orderGateway);
                ManagerPresenter presentation = new ManagerPresenter(screen, manager);
            */

            Application.Run(screen);
        }
    }
}
