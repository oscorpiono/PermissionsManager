using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestion_Des_Droit_D_access
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"data source = .\SQLEXPRESS; initial catalog = Gestion Des Droits; integrated security = true");
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        string path;
        public void Fill(string req)
        {
            con.Open();
            SqlCommand cm = new SqlCommand(req, con);
            SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            textBox1.Text = rd[0].ToString();
            textBox2.Text = rd[1].ToString();
            textBox3.Text = rd[2].ToString();
            path = rd[3].ToString();
            con.Close();
            rd.Close();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand($"update Applications set Name = '{textBox2.Text}', Description = '{textBox3.Text}', Logo = '{path}' where CodeApp = '{textBox1.Text}'", con);
            Message m = new Message();
            try
            {
                com.ExecuteNonQuery();
                m.Set("L'application a ete modifie avec success !", "Success");
                m.ShowDialog();
            }
            catch(Exception ex)
            {
                m.Set(ex.Message, "Erreur");
                m.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|Png Files (*.png)|*.png|All Files (*.*)|*.*";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                path = opd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool Move = false;
        int MouseX, MouseY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = true;
            MouseX = e.X;
            MouseY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move)
            {
                this.Location = new Point(this.Location.X + (e.X - MouseX), this.Location.Y + (e.Y - MouseY));
            }
        }
    }
}
