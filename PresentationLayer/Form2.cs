using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public interface IOrderManager
    {
        string orderNumber { set; get; }
        DateTime DateReceived { set; get; }
        string customerName { set; get; }
        string custPhone { set; get; }
        string custAddressline1 { set; get; }
        string custAddressline2 { set; get; }
        string custCountry { set; get; }
        string custType { set; get; }
        string price { set; get; }
        string timeHours { set; get; }
        DateTime deadline { set; }
        string systemRec { get; set; }
        string orderNotes { get; set; }
        string custOrderNotes { get; set; }
        DateTime startDate { get; set; }
        void orderItemListView(List<String> orderItems);
        bool acceptOrderRadioButton();
        void register(ManagerPresenter psr);
    }

    public partial class OrderManager : Form, IOrderManager
    {
        private ManagerPresenter presenter;

        public OrderManager()
        {
            InitializeComponent();
        }

        public string orderNumber
        {
            get { return txtOMOrderNumber.Text; }
            set { txtOMOrderNumber.Text = value; }

        }
        public DateTime DateReceived 
        {
            get { return OFMdateF.Value; }
            set { OFMdateF.Value = value; }
        }
        public string customerName 
        {
            get { return OFNnameF.Text; }
            set { OFNnameF.Text = value; }
        }
        public string custPhone 
        {
            get { return OFMphoneF.Text; }
            set { OFMphoneF.Text = value; }
        }
        public string custAddressline1
        {
            get { return OFMaddr1F.Text; }
            set { OFMaddr1F.Text = value; }
        }
        public string custAddressline2
        {
            get { return OFMaddr2F.Text; }
            set { OFMaddr2F.Text = value; }
        }
        public string custCountry
        {
            get { return OFMcountyF.Text; }
            set { OFMcountyF.Text = value; }
        }

        public string custType
        {
            get { return txtCustomerType.Text; }
            set { txtCustomerType.Text = value; }
        }

        public string price
        {
            get { return txtPriceActual.Text; }
            set { txtPriceActual.Text = value; }
        }
        public string timeHours
        {
            get { return txtOFTime.Text; }
            set { txtOFTime.Text = value; }
        }
        public DateTime deadline 
        {
            get { return OFMrttcF.Value; }
            set { OFMrttcF.Value = value; }
        }

        public string systemRec
        {
            get { return OFMsystemrecF.Text; }
            set { OFMsystemrecF.Text = value; }
        }
        public string orderNotes
        {
            get { return OFMmordernotesF.Text; }
            set { OFMmordernotesF.Text = value; }
        }

        public string custOrderNotes 
        {
            get { return OFMcnF.Text; }
            set { OFMcnF.Text = value; }
        }

        public DateTime startDate
        {
            get { return dtpMstartDate.Value; }
            set { dtpMstartDate.Value = value; }
        }

        public bool acceptOrderRadioButton()
        {
            if (OFMaoY.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void orderItemListView(List<String> orderItems)
        {
            foreach (string item in orderItems)
            {
                lstBoxItems.Items.Add(item);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        public void register(ManagerPresenter psr)
        {
            presenter = psr;
        }

        private void txtOMOrderNumber_Leave(object sender, EventArgs e)
        {
            presenter.EnquiryUpdate();
        }

        private void OFMsubmit_Click(object sender, EventArgs e)
        {
            presenter.SaveUpdateEnquiry();
        }
    }
}
