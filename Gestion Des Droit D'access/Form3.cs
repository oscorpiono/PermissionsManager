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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string CodeApp;
        SqlConnection con = new SqlConnection(@"data source = .\SQLEXPRESS; initial catalog = Gestion Des Droits; integrated security = true");
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

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            string req = $"Select * from Langues where CodeApp = '{CodeApp}'";
            if (textBox1.Text != "")
            {
                req += $" and CodeL like '%{textBox1.Text}%'";
            }
            if (textBox2.Text != "")
            {
                req += $" and CodeApp like '%{textBox2.Text}%'";
            }
            if (textBox3.Text != "")
            {
                req += $" and NomL like '%{textBox3.Text}%'";
            }
            SqlCommand com = new SqlCommand(req, con);
            SqlDataReader rd = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (rd.Read())
            {
                dataGridView1.Rows.Add(rd[0].ToString(), rd[1].ToString(), rd[2].ToString());
            }
            con.Close();
            rd.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con.Open();
            L();
            textBox2.Text = CodeApp;
            con.Close();
        }
        void L()
        {
            string req = $"Select * from Langues where CodeApp = '{CodeApp}'";
            SqlCommand com = new SqlCommand(req, con);
            SqlDataReader rd = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (rd.Read())
            {
                dataGridView1.Rows.Add(rd[0].ToString(), rd[1].ToString(), rd[2].ToString());
            }
            rd.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Message m = new Message();
            if(textBox1.Text != "")
            {
                try
                {
                    con.Open();
                    string req = $"insert into Langues values('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')";
                    SqlCommand com = new SqlCommand(req, con);
                    com.ExecuteNonQuery();
                    m.Set("La langue a ete ajoute avec success", "Success");
                    m.Show();
                    L();
                    textBox1.Text = "";
                    textBox3.Text = "";
                    con.Close();
                }
                catch (Exception ex)
                {
                    m.Set(ex.Message, "Erreur");
                    m.Show();
                }
            }
            else
            {
                m.Set("Vous devez remplir les champs !", "Erreur");
                m.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Message m = new Message();
            try
            {
                con.Open();
                string req = $"delete Langues where CodeL = '{dataGridView1.SelectedRows[0].Cells[0].Value}' and CodeApp = '{CodeApp}'";
                SqlCommand com = new SqlCommand(req, con);
                m.Set("Voulez vous vraiment supprimer cette langue ?", "Confirmation");
                m.ShowDialog();
                if(m.response == "ok")
                {
                    com.ExecuteNonQuery();
                    m.Set("La langue a ete supprimer avec success", "Success");
                    m.ShowDialog();
                    L();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                m.Set(ex.Message, "Erreur");
                m.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.CodeApp = textBox2.Text;
            f5.CodeL = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f5.NomL = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            f5.ShowDialog();
            con.Open();
            L();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
