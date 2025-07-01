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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace VP_Project.ADMIN
{
    public partial class Manageuserscs : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");

        public Manageuserscs()
        {
            InitializeComponent();
            Loaddata();
        }


        void Loaddata()
        {
            SqlCommand cmd = new SqlCommand("Select * from Users ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }





        private void Manageuserscs_Load(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"Insert into Users VALUES ('{txtname.Text}' , '{txtemail.Text}' , '{txtphone.Text}' ,'{txtaddress.Text}' , '{txtpass.Text}' )", con);
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

            SqlCommand cmd = new SqlCommand($"Select * from Users where UserId = {TXTID.Text} ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show($"NO Record found for ID {TXTID.Text}", "Wwarning");
                return;
            }



            cmd = new SqlCommand($"Delete from Users where userid = {TXTID.Text}", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data is DELETED Successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Loaddata();

        }

        private void btnedit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TXTID.Text) || string.IsNullOrEmpty(TXTID.Text))
            {
                MessageBox.Show("Enter a Valid Id to Edit ", "Warning");
                return;


            }
            SqlCommand cmd = new SqlCommand($"Select * from Users where UserId = {TXTID.Text}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show($"NO Record found for ID {TXTID.Text}", "Warning");
                return;
            }
            txtname.Text = dt.Rows[0][1].ToString();
            
            txtphone.Text = dt.Rows[0][3].ToString();
            txtaddress.Text = dt.Rows[0][4].ToString();
            txtpass.Text = dt.Rows[0][5].ToString();

            TXTID.Enabled = false;
            btnadd.Enabled = false;

            btnedit.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = false;




        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand($"Update Users SET  FullName = '{txtname.Text}'   , Phone = '{txtphone.Text}' , myAddress = '{txtaddress.Text}' , myPassword = '{txtpass.Text}' where UserId = {TXTID.Text} ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data is updated Successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Loaddata();

            txtname.Text = "";
            txtemail.Text = "";
            txtphone.Text = "";
            txtaddress.Text = "";
            txtpass.Text = "";

            TXTID.Enabled = true;
            btnadd.Enabled = true;
            btnedit.Enabled = true;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;



        }
    }
}
