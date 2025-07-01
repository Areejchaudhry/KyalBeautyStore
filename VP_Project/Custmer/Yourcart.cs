using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_Project.Custmer;

namespace VP_Project
{
    
    public partial class Yourcart : Form
    {
        int id = 0;
        


        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");


        int catid = 0;

        public Yourcart(int cusid  , int CATid)
        {
            InitializeComponent();
            id = cusid;
            catid = CATid;
            LoadCartItems();
            
            totaldisplay();
        }
        public Yourcart( )
        {
            InitializeComponent();
           
        }

        void LoadCartItems()
        {
            try
            {
                con.Open();
                // Use parameterized query instead of string interpolation
                SqlCommand cmd = new SqlCommand($"SELECT p.Name, p.Price, c.Quantity FROM Product p INNER JOIN Cart c ON p.ProductId = c.ProductFID WHERE c.UserFID = @userid ", con);



                cmd.Parameters.AddWithValue("@userId", id);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        decimal price = Convert.ToDecimal(row["Price"]);
                        flowLayoutPanel1.Controls.Add(crpanel(
                            row["Name"].ToString(),
                            quantity,
                            price));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error creating panel: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cart: " + ex.Message);
            }

            con.Close();
        }





        Panel crpanel(string name ,  int qua, decimal pr)
       
        {
            Panel panel = new Panel();
            panel.Width = 200;
            panel.Height = 200;
            panel.BackColor = Color.White;

            Label labelName = new Label()
            {
                Text = name ,
                Top = 10,
                Height = 50,
                Left = 10,
                Width = 180,

                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Black

            };

            Label labelPrice = new Label()
            {
                Text = pr.ToString(),
                Top = 70,
                Left = 10,
                Height = 40,
                Width = 180,
                ForeColor = Color.Black

            };


            Label labelquan = new Label()
            {
                Text = qua.ToString(),
                Top = 120,
                Height = 40,
                Left = 10,
                Width = 180,
                ForeColor = Color.Black

            };


            panel.Controls.Add(labelName);
            panel.Controls.Add(labelPrice);
            panel.Controls.Add(labelquan);

            return panel;
        }


        public decimal calculateTotal()
        {
            decimal total = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT SUM(p.Price * c.Quantity) FROM Product p INNER JOIN Cart c ON p.ProductId = c.ProductFID WHERE c.UserFID = {id} " , con);


            object result = cmd.ExecuteScalar();
            total = result != DBNull.Value ? Convert.ToDecimal(result) : 0;


            con.Close();

            return total;



        }

        public void totaldisplay()
        {
            decimal sum = calculateTotal();
            label3.Text = sum.ToString();
        }

        private void btnprod_Click(object sender, EventArgs e)
              {
            Products prod = new Products(id, catid);
            prod.Show();
        }

        public void btncheckout_Click(object sender, EventArgs e)
        {
            decimal total = calculateTotal();
            if (total <= 0)
            {
                totaldisplay();
                MessageBox.Show("Your cart is empty!");
                return;
            }

            checkout ch1 = new checkout(id,total);
            ch1.Show();
            
        }

        private void Yourcart_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categories cat = new Categories(id);
            cat.Show();
        }
    }
}
