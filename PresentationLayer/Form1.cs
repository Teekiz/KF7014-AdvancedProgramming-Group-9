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
        string itemDesc1 { get; set; }
        string itemDesc2 { get; set; }
        string itemDesc3 { get; set; }
        string itemQuant1 { get; set; }
        string itemQuant2 { get; set; }
        string itemQuant3 { get; set; }
        string getRadioButton();
        bool CerimonialSwordChecked();
        bool SwordChecked();
        bool ArmourChecked();

        bool termsChecked();

        void Form1_Load(object sender, EventArgs e);
        void label7_Click(object sender, EventArgs e);
        void label10_Click(object sender, EventArgs e);
        void label3_Click(object sender, EventArgs e);
        void OFCnameF_TextChanged(object sender, EventArgs e);
        void OFCsubmit_Click(object sender, EventArgs e);
        void register(EnquiryPresenter psr);
    }

    //Return text within form text boxes, including radio buttons for Customer Type, Dates, and Check boxes for Order Type.
    public partial class OFCcountry : Form, IOrderCust
    {
        private EnquiryPresenter presenter;

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
        //Return entered item descriptions.
        public string itemDesc1
        {
            get { return OFCot1desc.Text; }
            set { OFCot1desc.Text = value; }
        }

        public string itemDesc2
        {
            get { return OFCot2desc.Text; }
            set { OFCot2desc.Text = value; }
        }

        public string itemDesc3
        {
            get { return OFCot3desc.Text; }
            set { OFCot3desc.Text = value; }
        }
        //Return entered item quantity.
        public string itemQuant1
        {
            get { return OFCot1q.Text; }
            set { OFCot1q.Text = value; }
        }

        public string itemQuant2
        {
            get { return OFCot2q.Text; }
            set { OFCot2q.Text = value; }
        }

        public string itemQuant3
        {
            get { return OFCot3q.Text; }
            set { OFCot3q.Text = value; }
        }
        //Check for customer type selection (Radio Buttons).
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
            else if (OFCct3.Checked)
            { 
                return OFCct3.Text;
                }
            return null;
            }
        //Check if Cerimonial Swords has been checked.
        public bool CerimonialSwordChecked()
        {
            if (OFCot1.Checked)
            {
                return true;
            }
            return false;
        }
        //Check if Entertainment Swords has been checked.
        public bool SwordChecked()
        {
            if (OFCot2.Checked)
            {
                return true;
            }
            return false;
        }
        //Check if Armour has been checked.
        public bool ArmourChecked()
        {
            if (OFcot3.Checked)
            {
                return true;
            }
            return false;
        }
        // Check for terms and conditions check
        public bool termsChecked()
        {
            if (OFCtermscond.Checked)
            {
                return true;
            }
            return false;
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

        public void register(EnquiryPresenter psr)
        {
            presenter = psr;
        }
        //save enquiry on submit button activation
        public void OFCsubmit_Click(object sender, EventArgs e)
        {
            presenter.saveEnquiry();
        }
    }
}
