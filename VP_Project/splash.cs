using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Project
{
    public partial class splahscreen : Form
    {
        int progress = 0;
        public splahscreen()
        {
            InitializeComponent();
            timer1.Interval = 20;
            timer1.Start();
        }

        private void splahscreen_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progress++;
            if (progress >= 100)
            {
                timer1.Stop();
                this.Close();
            }

            progressBar1.Value = progress;
            label1.Text = progress.ToString() + "%";
        }
    }
}
