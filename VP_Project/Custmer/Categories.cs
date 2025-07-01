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

namespace VP_Project
{
    public partial class Categories : Form
    {

         int rip = 0;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Database1.mdf;Integrated Security=True ");
        public Categories()
        {
            InitializeComponent();
            LoadData();
        }
        public Categories(int id)
        {
            InitializeComponent();
            LoadData();
            rip = id;
        }



        void LoadData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Category", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                flowLayoutPanel1.Controls.Add(crpanel(Convert.ToInt32(dt.Rows[i][0]), dt.Rows[i][1].ToString() , dt.Rows[i][2].ToString())  );
            }



        }

        Panel crpanel( int catid , string name , string details)
        {
            Panel p = new Panel();
            p.BackColor = Color.FloralWhite;
            p.BorderStyle = BorderStyle.Fixed3D;
            p.Height = 350;
            p.Width = 180;

            PictureBox pictureBox = new PictureBox()
            {
                Image = Image.FromFile("C:\\Users\\Admin\\source\\repos\\VP_Project\\VP_Project\\Resources\\categoriespic.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 160,
                Height = 150,
                Top = 10,
                Left = 10,
            };
            Label label1 = new Label()
            {
                Height = 40,
                Width = 130,
                Top = 170,
                Left = 10,
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = name,
                ForeColor = Color.Black,
            };

            Label label2 = new Label()
            {
                Height = 50,
                Width = 130,
                Top = 220,
                Left = 10,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = details ,
                ForeColor = Color.Black,
            };



            Button button = new Button()
            {
                Text = "View Products",

                Height = 40,
                Width = 130,
                Top = 280,
                Left = 10,
                ForeColor = Color.White,
                BackColor = Color.SeaGreen

            };
            button.Click += (sender, e) =>
            {
                MessageBox.Show(label1.Text);
                Products prod = new Products( rip , catid);
                prod.Show();


            };


            p.Controls.Add(label1);
            p.Controls.Add(label2);
            p.Controls.Add(button);

            p.Controls.Add(pictureBox);
            return p;
        }




        private void Categories_Load(object sender, EventArgs e)
        {

        }
    }
}
