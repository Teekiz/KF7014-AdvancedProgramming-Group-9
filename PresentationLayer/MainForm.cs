﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer;
using DataAccessLayer;

//Developed by Lewis Barton
//Main form linking other forms. Contains links to Customer form, manager form, schedule form, and credits form.

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        IEnquiryGateway enquiryGateway;
        IOrderItemGateway orderItemGateway;
        ICustomerGateway customerGateway;
        IOrderGateway orderGateway;

        public MainForm()
        {
            enquiryGateway = EnquiryGateway.Instance;
            orderItemGateway = OrderItemGateway.Instance;
            customerGateway = CustomerGateway.Instance;
            orderGateway = OrderGateway.Instance;

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        //On button click, load relevant form.
        private void MFb1_Click(object sender, EventArgs e)
        {
            OFCcountry screen = new OFCcountry();
            IEnquiryModel enq = new EnquiryModel(enquiryGateway, orderItemGateway, customerGateway);
            EnquiryPresenter presentation = new EnquiryPresenter(screen, enq);
            screen.ShowDialog();
        }

        private void MFb2_Click(object sender, EventArgs e)
        {
            OrderManager screen = new OrderManager();
            IManagerModel manager = new ManagerModel(enquiryGateway, customerGateway, orderItemGateway, orderGateway);
            ManagerPresenter presentation = new ManagerPresenter(screen, manager);
            screen.ShowDialog();
        }

        private void MFb3_Click(object sender, EventArgs e)
        {
            Schedule screen = new Schedule();
            IScheduleModel model = new ScheduleModel(orderGateway, enquiryGateway, orderItemGateway);
            SchedulePresenter presentation = new SchedulePresenter(screen, model);
            screen.ShowDialog();
        }

        private void MFb4_Click(object sender, EventArgs e)
        {
            Credits screen = new Credits();
            screen.ShowDialog();
        }
    }
}
