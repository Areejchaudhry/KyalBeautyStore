using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VP_Project
{
    public partial class Products : Form
    {
        int ID = 0;
        int categoryid = 0;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");


        public Products()
        {
            InitializeComponent();
           
            LoadData();
        }
        public Products(int cusid)
        {
            InitializeComponent();
            ID = cusid;
            LoadData();
        }
        public Products(int cusid , int id)
        {
            InitializeComponent();
            ID = cusid;
            categoryid = id;
            LoadData();
            
        }




        void LoadData()
        {
            SqlCommand cmd;

            if(categoryid > 0)
            {
                cmd = new SqlCommand($"SELECT * FROM Product WHERE CategoryId = {categoryid} ", con);


            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Product ", con);

            }


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            flowLayoutPanel1.Controls.Clear();


            for (int i = 0; i < dt.Rows.Count; i++)
            {

                flowLayoutPanel1.Controls.Add(crpanel(Convert.ToInt32(dt.Rows[i][0]) ,  
                    dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString() , Convert.ToInt32(dt.Rows[i][3]) ,
                    Convert.ToInt32(dt.Rows[i][5])));
            }


        }

        Panel crpanel(int id , string name, string Desc, int catid , decimal pr)
        {
            Panel p = new Panel();
            p.BackColor = Color.FloralWhite;
            p.BorderStyle = BorderStyle.Fixed3D;
            p.Height = 450;
            p.Width = 200;

            PictureBox pictureBox = new PictureBox()
            {
                Image = Image.FromFile("C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Resources\\productspic.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 180,
                Height = 150,
                Top = 10,
                Left = 10,
            };
            Label label1 = new Label()
            {
                Height = 30,
                Width = 130,
                Top = 190,
                Left = 10,
                Text = name,
                ForeColor = Color.Black,
                Font = new Font ("Arial" ,16 , FontStyle.Bold )
            };

            Label label2 = new Label()
            {
                Height = 30,
                Width = 130,
                Top = 230,
                Left = 10,

                Text = "Description : " + Desc ,
                ForeColor = Color.Black
            };


            TextBox quantity = new TextBox()
            {
                Text = "Enter Quantity" , 
                Height = 30,
                Width = 130,
                Top = 270,
                Left = 10,
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
            quantity.Enter += (s, e) =>
            {
                if (quantity.Text == "Enter Quantity")
                {
                    quantity.Text = "";
                    quantity.ForeColor = Color.Black; // optional: change text color
                }
            };







            Label label5 = new Label()
            {
                Height = 30,
                Width = 130,
                Top = 310,
                Left = 10,

                Text =  "Price :   " +  pr.ToString(),  
                ForeColor = Color.Black,
            };


            Button button = new Button()
            {
                Text = "Add to Cart",

                Height = 40,
                Width = 130,
                Top = 360,
                Left = 10,
                ForeColor = Color.White,
                BackColor = Color.DarkSeaGreen

            };


            button.Click += (sender, e) =>
            {

                try
                {
                    
                    SqlCommand cmd = new SqlCommand("INSERT INTO Cart (UserFID, ProductFID, Quantity) VALUES (@userId, @productId, @quantity)", con);
                    cmd.Parameters.AddWithValue("@userId", ID);
                    cmd.Parameters.AddWithValue("@productId", id);
                    int qty;
                    if (int.TryParse(quantity.Text, out qty) && qty > 0)
                    {
                        cmd.Parameters.AddWithValue("@quantity", qty);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid quantity.");
                        return;
                    }


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product Added to Cart", "Confirmation Message");

                }
                catch(Exception EX)
                {
                    MessageBox.Show("Something went wrong!"+EX.Message);
                }
                con.Close();
                Yourcart c1 = new Yourcart(ID , categoryid);
                c1.Show();

            };


            p.Controls.Add(label2);
            p.Controls.Add(label1);
            p.Controls.Add(button);
            p.Controls.Add(quantity);
            p.Controls.Add(label5);

            p.Controls.Add(pictureBox);
            return p;
        }



        private void Products_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
