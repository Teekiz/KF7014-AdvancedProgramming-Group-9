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
    public interface ISchedule
    { 
        string scheduleBox { get; set; }
        void register(SchedulePresenter psr);
    }

    public partial class Schedule : Form
    {
        SchedulePresenter presenter;
        public Schedule()
        {
            InitializeComponent();
        }

        public string scheduleBox
        {
            get { return scheduleBox.Text; }
            set { scheduleBox.Text = value; }
        }

        public void register(SchedulePresenter psr)
        {
            presenter = psr;
        }
    }
}
