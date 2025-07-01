using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Project
{
    public partial class CustomerRegister : Form
    {
        public CustomerRegister()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Required Field


            if (txtcpass.Text == "" || texttxtemail.Text == "")
            {
                MessageBox.Show("Please Fill all required Fields Properly..", "Incomplete Form");
                return;

            }



            if (!Regex.IsMatch(texttxtemail.Text, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$"))
            {
                MessageBox.Show("Email is not in correct format", "Incomplete Form");
                return;
            }

            //Password Strenth
            if (!Regex.IsMatch(txtpass.Text, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"))
            {
                MessageBox.Show("Password must contaain an upercase, a lower a symbol and must be 8 characters long ", "Weak Password");
                return;
            }


            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");



            SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES ('" + txtname.Text + "','" + texttxtemail.Text + "','" + txtphone.Text + "','" + txtaddress.Text + "','" + txtpass.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            //CONFIRMATION
            MessageBox.Show("Account Registered!", "Success");

            Customerlogin l1 = new Customerlogin();
            l1.ShowDialog();
            this.Hide();





















        }

        private void CustomerRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
