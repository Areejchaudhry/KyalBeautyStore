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
    public partial class Customerhome : Form
    {
        int id =0;
        public Customerhome()
        {
            InitializeComponent();
        }
        public Customerhome(int cusID)
        {
            InitializeComponent();
            id = cusID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choice2 c1 = new Choice2(id);
            c1.ShowDialog();
            this.Close();
        }

        private void Customerhome_Load(object sender, EventArgs e)
        {

        }
    }
}
