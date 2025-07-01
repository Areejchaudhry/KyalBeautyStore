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
using System.Xml.Linq;

namespace VP_Project.Custmer
{

    public partial class checkout : Form
    {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");

        string stat = "Confirmed";
        int userid = 0;
        public decimal ordertotal;
        public checkout(int ID, decimal total)
        {
            InitializeComponent();
            ordertotal = total;
            userid = ID;
            Laodcustomerdata();

            label3.Text = "RS." + ordertotal.ToString();

        }
        void Laodcustomerdata()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT FullName, Email, Phone, myAddress FROM Users WHERE UserId = {userid} ", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    labelname.Text = reader["FullName"].ToString();
                    labelemail.Text = reader["Email"].ToString();
                    labelphone.Text = reader["Phone"].ToString();
                    labeladdress.Text = reader["myAddress"].ToString();
                }
                else
                {
                    MessageBox.Show("Customer not found!");
                    this.Close();
                }


            }

            con.Close();

        }


            public void checkout_Load(object sender, EventArgs e)
        {

        }
        
            private void btnconfirm_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Orders (UserId, OrderDate, TotalAmount, DeliverAddress, PaymentMethod) VALUES (@uid, @date, @total, @addr, @method)", con);

            cmd.Parameters.AddWithValue("@uid", userid);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value); // Correctly passes DateTime
            cmd.Parameters.AddWithValue("@total", ordertotal);
            cmd.Parameters.AddWithValue("@addr", labeladdress.Text);
            cmd.Parameters.AddWithValue("@method", radioButton1.Checked ? "Cash on Delivery" : "Other"); // Adjust based on your logic

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Your Order has been successfully Placed.","Confirmation Message");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customerhome h1 = new Customerhome(userid);
            h1.Show();
        }
    }

    }

