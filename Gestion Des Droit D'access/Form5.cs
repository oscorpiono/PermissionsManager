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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"data source = .\SQLEXPRESS; initial catalog = Gestion Des Droits; integrated security = true");
        public string CodeApp, CodeL, NomL;
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Message m = new Message();
            con.Open();
            SqlCommand com = new SqlCommand($"update Langues set NomL = '{textBox3.Text}' where CodeL = '{textBox1.Text}' and CodeApp = '{textBox2.Text}'", con);
            try
            {
                com.ExecuteNonQuery();
                m.Set("La langue a ete modifie avec success", "Success");
                m.ShowDialog();
            }
            catch (Exception ex)
            {
                m.Set(ex.Message, "Erreur");
                m.ShowDialog();
            }
            con.Close();
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

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox2.Text = CodeApp;
            textBox1.Text = CodeL;
            textBox3.Text = NomL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
