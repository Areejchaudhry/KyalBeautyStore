using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Project
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            Adminlogin adminlogin = new Adminlogin();
            adminlogin.ShowDialog();
            this.Close();
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            Customerlogin c1= new Customerlogin();
            c1.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
