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
    public interface IOrderCust 
    {
        DateTime birthdate { get; set; }
        DateTime deadline { get; set; }
        string name { get; set; }
        string addressline1 { get; set; }
        string county { get; set; }
        string country { get; set; }
        string townCity { get; set; }
        string addressline2 { get; set; }
        string phone { get; set; }
        string postcode { get; set; }
        string orderNotes { get; set; }
        string getRadioButton();

        void Form1_Load(object sender, EventArgs e);
        void label7_Click(object sender, EventArgs e);
        void label10_Click(object sender, EventArgs e);
        void label3_Click(object sender, EventArgs e);
        void OFCnameF_TextChanged(object sender, EventArgs e);
        void OFCsubmit_Click(object sender, EventArgs e);
        void register(Presentation psr);
    }
    public partial class OFCcountry : Form, IOrderCust
    {
        private Presentation presenter;

        public string name
        {
            get { return OFCnameF.Text; }
            set { OFCnameF.Text = value; }
        }
        public string phone
        {
            get { return OFCphoneF.Text; }
            set { OFCphoneF.Text = value; }
        }
        public string addressline1
        {
            get { return OFCaddr1F.Text; }
            set { OFCaddr1F.Text = value; }
        }
        public string addressline2
        {
            get { return OFCaddr2F.Text; }
            set { OFCaddr2F.Text = value; }
        }
        public string county
        {
            get { return OFCcountyF.Text; }
            set { OFCcountyF.Text = value; }
        }

        public string country
        {
            get { return OFCcountryF.Text; }
            set { OFCcountryF.Text = value; }
        }

        public string townCity
        {
            get { return OFCtownF.Text; }
            set { OFCtownF.Text = value; }
        }

        public string postcode
        {
            get { return OFCpostcodeF.Text; }
            set { OFCpostcodeF.Text = value; }
        }

        public string orderNotes
        {
            get { return OFCnotesF.Text; }
            set { OFCnotesF.Text = value; }
        }



        public DateTime birthdate
        {
            get { return OFCbirthdateF.Value; }
            set { OFCbirthdateF.Value = value; }
        }

        public DateTime deadline
        {
            get { return OFCncdF.Value; }
            set { OFCncdF.Value = value; }

        }

        public OFCcountry()
        {
            InitializeComponent();
        }
        public string getRadioButton()
            {
            OFCgroupbox.Controls.Add(OFCct1);
            OFCgroupbox.Controls.Add(OFCct2);
            OFCgroupbox.Controls.Add(OFCct3);

            if (OFCct1.Checked)
            {
                return OFCct1.Text;
            }
            else if (OFCct2.Checked)
            {
                return OFCct2.Text;
            }
            else
            { 
                return OFCct3.Text;
                }
            }
        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void label7_Click(object sender, EventArgs e)
        {

        }

        public void label10_Click(object sender, EventArgs e)
        {

        }

        public void label3_Click(object sender, EventArgs e)
        {

        }

        public void OFCnameF_TextChanged(object sender, EventArgs e)
        {

        }

        public void register(Presentation psr)
        {
            presenter = psr;
        }
        public void OFCsubmit_Click(object sender, EventArgs e)
        {
            presenter.saveCustomer();
            presenter.saveEnquiry();
        }
    }
}
