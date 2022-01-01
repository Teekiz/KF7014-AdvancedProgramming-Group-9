using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace PresentationLayer
{
    public interface ISchedule
    {
        void populateScheduleDataGrid(Order order, Enquiry enquiry, int count, string scheduleCheck);
        void changeDGVColour();
        void register(SchedulePresenter psr);
    }

    public partial class Schedule : Form, ISchedule
    {
        SchedulePresenter presenter;

        public Schedule()
        {
            InitializeComponent();
        }
        public void populateScheduleDataGrid(Order order, Enquiry enquiry, int count, string scheduleCheck)
        {
            dgvSchedule.Rows.Add(order.orderID, order.scheduledStartDate, order.confirmedDeadline, enquiry.orderNotes, count, order.progressCompleted, scheduleCheck);
        }

        public void changeDGVColour()
        {
            foreach (DataGridViewRow row in dgvSchedule.Rows)
            {
                //based on the answer by CAbbott (2010) on how to get the value of a datagridview column
                //https://stackoverflow.com/questions/2581265/for-a-datagridview-how-do-i-get-the-values-from-each-row


                if (row.Cells[6].Value.ToString() == "Yes")
                {
                    //this code is partially based on Ehsans (2013) comment where they suggest how to change he colour of a row column.
                    //https://stackoverflow.com/questions/17728009/changing-datagridview-cell-color-dynamically
                    row.Cells[6].Style.BackColor = Color.Green;
                }
                else { row.Cells[6].Style.BackColor = Color.Red; }
            }    
        }

        public void register(SchedulePresenter psr)
        {
            presenter = psr;
        }

        private void Schedule_Load(object sender, EventArgs e)
        {

        }

        private void dgvSchedule_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the order ID of the selected row
            presenter.rowSelected(Int32.Parse(dgvSchedule.Rows[e.RowIndex].Cells[0].Value.ToString()));
        }
    }
}
