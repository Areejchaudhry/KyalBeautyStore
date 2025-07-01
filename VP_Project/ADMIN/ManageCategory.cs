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
    public partial class ManageCategory : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");

        public ManageCategory()
        {
            InitializeComponent();
            Loaddata();
        }


        void Loaddata()
        {
            SqlCommand cmd = new SqlCommand("Select * from Category ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }




        private void ManageCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"Insert into Category VALUES ('{txtname.Text}' , '{txtdetails.Text}')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Loaddata();


            MessageBox.Show("The Category is added ", "DATA ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(TXTID.Text))
                {
                    MessageBox.Show("Please Enter ID to delete the Record.", "ID NOT ENTERED ");
                    return;
                }
                SqlCommand cmd = new SqlCommand($"SELECT  * from Category  where CategoryId = {TXTID.Text} ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show($"NO Record found for ID {TXTID.Text}", "Warning");
                    return;
                }

                cmd = new SqlCommand($"DELETE From Category where CategoryId = '{TXTID.Text}'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("This Item has been Deleted Successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                Loaddata();

            }
            catch(Exception ex)
            {

                MessageBox.Show("Something went wrong.Please Try again."+ ex.Message);

            }

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXTID.Text) || string.IsNullOrEmpty(TXTID.Text))
            {
                MessageBox.Show("Enter a Valid Id to Edit ", "Warning");
                return;


            }
            SqlCommand cmd = new SqlCommand($"SELECT  * from Category where CategoryId = {TXTID.Text}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show($"NO Record found for ID {TXTID.Text}", "Warning");
                return;
            }

            txtname.Text = dt.Rows[0][1].ToString();
            txtdetails.Text = dt.Rows[0][2].ToString();


            TXTID.Enabled = false;
            btnupdate.Visible = true;

            btnadd.Enabled = false;
            btnedit.Enabled = false;
            btndelete.Enabled = false;


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand($"Update Category SET   Name = '{txtname.Text}' , Details = '{txtdetails.Text} ' where CategoryId = {TXTID.Text}  ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data is updated Successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Loaddata();

            txtname.Text = "";
            txtdetails.Text = "";


            TXTID.Enabled = true;
            btnadd.Enabled = true;
            btnedit.Enabled = true;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;

        }
    }
}
