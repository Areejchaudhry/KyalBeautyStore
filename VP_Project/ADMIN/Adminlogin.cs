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
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            InitializeComponent();
        }

        private void Adminlogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtname.Text == "ADMIN" && txtpassword.Text == "Admin@1234")
            {
                MessageBox.Show("Successfully Logged In!", "Success");
                Adminhome h1 = new Adminhome();
                h1.ShowDialog();
                this.Close();
            }
        }
    }
}
