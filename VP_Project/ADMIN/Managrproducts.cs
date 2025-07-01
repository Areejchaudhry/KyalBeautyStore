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
    public partial class Managrproducts : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");

        public Managrproducts()
        {
            InitializeComponent();
            Loadcats();
            Loaddata();
        }

        void Loadcats()
        {
            SqlCommand cmd = new SqlCommand("Select * from Category ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbcategory.DataSource = dt;
            cbcategory.DisplayMember = dt.Columns[1].ToString();
            cbcategory.ValueMember = dt.Columns[0].ToString();

        }

        void Loaddata()
        {
            SqlCommand cmd = new SqlCommand("Select * from Product ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void Managrproducts_Load(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"Insert into Product VALUES ('{txtname.Text}' , '{txtdescription.Text}' , '{cbcategory.SelectedValue}' , '{txtquantity.Text}' , '{txtprice.Text}'  )", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Loaddata();


            MessageBox.Show("The Product is added ", "DATA ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand cmd = new SqlCommand($"SELECT  * from Product where ProductId = {TXTID.Text} ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show($"NO Record found for ID {TXTID.Text}", "Warning");
                    return;
                }

                cmd = new SqlCommand($"DELETE From Product where ProductId = '{TXTID.Text}'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("This Item has been Deleted Successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                Loaddata();

            }
            catch(Exception ex)
            {

                MessageBox.Show("Something went wrong.Please Try again."+ex.Message);

            }

        }

        private void btnedit_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(TXTID.Text))
            {
                MessageBox.Show("Enter a Valid Id to Edit ", "Warning");
                return;


            }
            SqlCommand cmd = new SqlCommand($"SELECT  * from Product where ProductId = {TXTID.Text}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show($"NO Record found for ID {TXTID.Text}", "Warning");
                return;
            }

            txtname.Text = dt.Rows[0][1].ToString();
            txtdescription.Text = dt.Rows[0][2].ToString();
            cbcategory.SelectedValue = dt.Rows[0][3].ToString();
            txtquantity.Text = dt.Rows[0][4].ToString();
            txtprice.Text = dt.Rows[0][5].ToString();


            TXTID.Enabled = false;
            btnupdate.Visible = true;

            btnadd.Enabled = false;
            btndelete.Enabled = false;
            btnedit.Enabled = false;
           

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"Update Product SET Name = '{txtname.Text}' , Description =  '{txtdescription.Text}' , CategoryId = {cbcategory.SelectedValue} , Quantity = '{txtquantity.Text}' ,Price = '{txtprice.Text}' where ProductId = {TXTID.Text} ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data is updated Successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Loaddata();

            txtname.Text = "";
            txtdescription.Text = "";
            txtprice.Text = "";
            txtquantity.Text = "";
            cbcategory.Text = "";

            TXTID.Enabled = true;
            btnadd.Enabled = true;
            btnedit.Enabled = true;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
