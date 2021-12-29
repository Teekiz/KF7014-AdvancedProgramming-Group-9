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
    public partial class AccessPage : Form
    {
        public AccessPage()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void APbutton1_Click(object sender, EventArgs e)
        {
            Schedule f2 = new Schedule();
            f2.ShowDialog();
        }

        private void APbutton2_Click(object sender, EventArgs e)
        {
            OrderManager f2 = new OrderManager();
            f2.ShowDialog();
        }
    }
}
