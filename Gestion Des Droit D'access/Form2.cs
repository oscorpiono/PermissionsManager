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
    public partial class Form2 : Form
    {
        bool Move = false;
        int MouseX, MouseY;
        SqlConnection con = new SqlConnection(@"data source = .\SQLEXPRESS; initial catalog = Gestion Des Droits; integrated security = true");
        string LogoPath;

        public Form2()
        {
            InitializeComponent();
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Message m = new Message();
            if(textBox1.Text != "")
            {
                con.Open();
                SqlCommand com = new SqlCommand($"insert into Applications values('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{LogoPath}')", con);
                try
                {
                    com.ExecuteNonQuery();
                    m.Set("L'application a ete ajoute avec success !", "Success");
                    m.ShowDialog();
                }
                catch (Exception ex)
                {
                    m.Set(ex.Message, "Erreur");
                    m.ShowDialog();
                }
                con.Close();
            }
            else
            {
                m.Set("Vous devez remplir les champs !", "Erreur");
                m.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|Png Files (*.png)|*.png|All Files (*.*)|*.*";
            if(opd.ShowDialog() == DialogResult.OK)
            {
                LogoPath = opd.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LogoPath = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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
