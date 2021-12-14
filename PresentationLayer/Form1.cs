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
        string name { get; set; }
        string address { get; set; }
        string country { get; set; }
        void Form1_Load(object sender, EventArgs e);
        void label7_Click(object sender, EventArgs e);
        void label10_Click(object sender, EventArgs e);
        void label3_Click(object sender, EventArgs e);
        void OFCnameF_TextChanged(object sender, EventArgs e);
        void OFCsubmit_Click(object sender, EventArgs e);
        void register(Presentation psr);
    }
    public partial class OrderCust : Form, IOrderCust
    {
        private Presentation presenter;

        public string name 
        {
            get { return OFCnameF.Text;}
            set { OFCnameF.Text = value; }
        }
        public string address
        {
            get { return OFCaddr1F.Text; }
            set { OFCaddr1F.Text = value; }
        }
        public string country
        {
            get { return OFCcountyF.Text; }
            set { OFCcountyF.Text = value; }
        }

        public OrderCust()
        {
            InitializeComponent();
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
        }
    }
}
