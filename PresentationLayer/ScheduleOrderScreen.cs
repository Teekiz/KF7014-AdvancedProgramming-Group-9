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
    public interface IScheduleOrderScreen
    { 
        string orderNotes { get; set; }
        string progressCompleted { get; set; }
        string orderItemsList { get; set; }
        void register(ScheduleOrderScreenPresenter psr);
    }
    public partial class ScheduleOrderScreen : Form, IScheduleOrderScreen
    {
        ScheduleOrderScreenPresenter presenter;

        public ScheduleOrderScreen()
        {
            InitializeComponent();
        }

        public string orderNotes
        {
            get { return rtbOrderNotes.Text; }
            set { rtbOrderNotes.Text = value; }
        }

        public string progressCompleted
        {
            get { return txtPercentComplete.Text; }
            set { txtPercentComplete.Text = value; }
        }

        public string orderItemsList
        {
            get { return lstOrders.Text; }
            set { lstOrders.Items.Add(value); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            presenter.updateOrder();
        }

        public void register(ScheduleOrderScreenPresenter psr)
        {
            presenter = psr;
        }
    }
}
