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
    public partial class Choice2 : Form
    {
        int cusid = 0;
        public Choice2()
        {
            InitializeComponent();
        }
        public Choice2(int ID)
        {
            InitializeComponent();
            cusid = ID;
        }

        private void btncats_Click(object sender, EventArgs e)
        {
            Categories c1 = new Categories(cusid);
            c1.ShowDialog();
            this.Close();
        }

        private void btnproducts_Click(object sender, EventArgs e)
        {
            Products c1 = new Products(cusid);
            c1.ShowDialog();
            this.Close();
        }

        private void Choice2_Load(object sender, EventArgs e)
        {

        }
    }
}
