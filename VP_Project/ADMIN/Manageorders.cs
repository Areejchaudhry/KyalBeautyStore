using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Project.ADMIN
{
    public partial class Manageorders : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");

        public Manageorders()
        {
            InitializeComponent();
            Loaddata();
            Loadusers();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void Loaddata()
        {
            SqlCommand cmd = new SqlCommand("Select * from Orders ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void Loadusers()
        {
            SqlCommand cmd = new SqlCommand("Select * from Users ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbuserid.DataSource = dt;
            cbuserid.DisplayMember = dt.Columns[1].ToString();
            cbuserid.ValueMember = dt.Columns[0].ToString();

        }

        private void Manageorders_Load(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"Insert into Orders VALUES ('{cbuserid.SelectedValue}'  ,'{dateTimePicker1.Text}' , '{txtamount.Text}' ,'{txtname.Text}' , '{rbcash.Text}' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Loaddata();
                MessageBox.Show(" The User is added Sucessfully.", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TXTID.Text) || string.IsNullOrEmpty(TXTID.Text))
            {
                MessageBox.Show("Enter a Valid ID to delete Item", "Warning");
                return;

            }

            SqlCommand cmd = new SqlCommand($"Select * from Orders where OrderId = {TXTID.Text} ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show($"NO Record found for ID {TXTID.Text}", "Warning");
                return;
            }



            cmd = new SqlCommand($"Delete from Orders where OrderId = {TXTID.Text}", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data is Added Successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Loaddata();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TXTID.Text) || string.IsNullOrEmpty(TXTID.Text))
            {
                MessageBox.Show("Enter a Valid Id to Edit ", "Warning");
                return;


            }
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from Orders where OrderId = {TXTID.Text}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show($"NO Record found for ID {TXTID.Text}", "Warning");
                return;

            }
            con.Close();
            cbuserid.SelectedValue = dt.Rows[0][1].ToString();
            dateTimePicker1.Text = dt.Rows[0][2].ToString();
            txtamount.Text = dt.Rows[0][3].ToString();
            
            txtname.Text = dt.Rows[0][4].ToString();
            rbcash.Text = dt.Rows[0][5].ToString();

            TXTID.Enabled = false;
            btnadd.Enabled = false;

            btnedit.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = false;

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"Update Orders SET UserId = {cbuserid.SelectedValue} , OrderDate = '{dateTimePicker1.Text}' , TotalAmount = '{txtamount.Text}' , DeliverAddress = '{txtname.Text}' , PaymentMethod = '{rbcash.Text}' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data is updated Successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Loaddata();

            txtname.Text = "";
            rbcash.Text = "";
            cbuserid.Text = "";
            txtamount.Text = "";
            dateTimePicker1.Text = "";

            TXTID.Enabled = true;
            btnadd.Enabled = true;
            btnedit.Enabled = true;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;


        }
    }
}
