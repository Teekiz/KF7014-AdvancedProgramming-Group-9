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
        DateTime requestedTTC { set; }
        DateTime estimatedTTC { set; }
        DateTime currentTTC { set; }
        DateTime orderDate { set; }
        DateTime custBirthDate { set; }
        string priceOffer { get; set; }
        string manOrderNotes { get; set; }
        string custCounty { set; }
        string custCountry { set; }
        string custTownCity { set; }
        string custAddressline1 { set; }
        string custAddressline2 { set; }
        string custPhone { set; }
        string custPostcode { set; }
        string custOrderNotes { set; }
        string systemRec { set; }
        string acceptOrderRadioButton();
        string customerTypeRadioButton();
        void Form2_Load(object sender, EventArgs e);
        void label4_Click(object sender, EventArgs e);
        void label18_Click(object sender, EventArgs e);
        void register(ManagerPresenter psr);
    }

    public partial class OrderManager : Form, IOrderManager
    {
        private EnquiryPresenter presenter;

        public OrderManager()
        {
            InitializeComponent();
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
        public void register(EnquiryPresenter psr)
        {
            presenter = psr;
        }

        public void OFCsubmit_Click(object sender, EventArgs e)
        {
            presenter.saveEnquiry();
        }
    }
}
