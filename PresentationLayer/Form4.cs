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
    public interface IOrderManagerChanges
    {
        string conflictOrderNumber { set; get; }
        DateTime conclifctDeadline { set; get; }
        DateTime conflictStartDate { get; set; }
        string existingOrderNumber { set; get; }
        DateTime existingDeadline { set; get; }
        DateTime existingStartDate { get; set; }
    }
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public DateTime conflictDeadline
        {
            get { return CendDate.Value; }
            set { CendDate.Value = value; }
        }

        public DateTime conflictStartDate
        {
            get { return CstartDate.Value; }
            set { CstartDate.Value = value; }
        }

        public string conflictOrderNumber
        {
            get { return CorderID.Text; }
            set { CorderID.Text = value; }
        }

        public DateTime existingDeadline
        {
            get { return EendDate.Value; }
            set { EendDate.Value = value; }
        }

        public DateTime existingStartDate
        {
            get { return EstartDate.Value; }
            set { EstartDate.Value = value; }
        }

        public string existingOrderNumber
        {
            get { return EorderID.Text; }
            set { EorderID.Text = value; }
        }




















        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void CorderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void CstartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CendDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EorderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void EendDate_ValueChanged(object sender, EventArgs e)
        {

        }

        public void register(ManagerPresenter psr)
        {
            presenter2 = psr;
        }

        private void txtOMOrderNumber_Leave(object sender, EventArgs e)
        {
            presenter2.EnquiryUpdate();
        }

        private void pushChanges_Click(object sender, EventArgs e)
        {
            presenter2.SaveUpdateEnquiry();
        }
    }
}
