using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VP_Project
{
    public partial class Customerlogin : Form
    {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");
        public Customerlogin()
        {
            InitializeComponent();
        }

        private void Customerlogin_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            int customerid = 0;
            SqlCommand cmd = new SqlCommand("Select * from  Users where Email = '" + txtemail.Text + "' AND myPassword = '" + txtpass.Text + "'", con);

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                customerid = (int)rd["UserId"];
                MessageBox.Show("Successfully Logged In.", "Success Message");
                Customerhome home = new Customerhome(customerid);
                home.ShowDialog();
                this.Hide();


            }
            else
            {
                con.Close();
                MessageBox.Show("Email or Password Incorrect!");


            }
            con.Close();

        }

        public void btnregister_Click(object sender, EventArgs e)
        {




            CustomerRegister home = new CustomerRegister();
            home.ShowDialog();
            this.Hide();
        }


















    }
      




    }


               
            
        

    
