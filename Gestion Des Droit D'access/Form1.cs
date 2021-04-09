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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"data source = .\SQLEXPRESS; initial catalog = Gestion Des Droits; integrated security = true");
        bool Move = false;
        int MouseX, MouseY;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ClearSelection();
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move)
            {
                this.Location = new Point(this.Location.X + (e.X - MouseX), this.Location.Y + (e.Y - MouseY));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            con.Open();
            L();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string req = "Select * from Applications where 1 = 1";
            if (textBox1.Text != "")
            {
                req += $" and CodeApp like '%{textBox1.Text}%'";
            }
            if (textBox2.Text != "")
            {
                req += $" and Name like '%{textBox2.Text}%'";
            }
            SqlCommand com = new SqlCommand(req, con);
            SqlDataReader rd = com.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (rd.Read())
            {
                Image m = Image.FromFile(rd[3].ToString());
                dataGridView1.Rows.Add(rd[0].ToString(), rd[1].ToString(), rd[2].ToString(), m);
            }
            con.Close();
            rd.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            L();
            con.Close();
        }

        public void L()
        {
            dataGridView1.Rows.Clear();
            string req = "Select * from Applications where 1 = 1";
            SqlCommand com = new SqlCommand(req, con);
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                Image m = Image.FromFile(rd[3].ToString());
                dataGridView1.Rows.Add(rd[0].ToString(), rd[1].ToString(), rd[2].ToString(), m);
            }
            rd.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                con.Open();
                string req = $"delete Applications where CodeApp = '{dataGridView1.SelectedRows[0].Cells[0].Value}'";
                SqlCommand com = new SqlCommand(req, con);
                Message m = new Message();
                m.Set("Voulez vous vraiment supprimer cette application, ce jeste va supprimer toute ses autre relations", "Confirmation");
                m.ShowDialog();
                if (m.response == "ok")
                {
                    try
                    {
                        com.ExecuteNonQuery();
                        m.Set("L'application a ete supprimer avec success", "Success");
                        m.ShowDialog();
                        L();
                    }
                    catch (Exception ex)
                    {
                        m.Set(ex.Message, "Erreur");
                        m.ShowDialog();
                    }
                }
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Form4 f4 = new Form4();
                f4.Fill($"select * from Applications where CodeApp = '{dataGridView1.SelectedRows[0].Cells[0].Value}'");
                f4.ShowDialog();
                con.Open();
                L();
                con.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();;
            f3.CodeApp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f3.ShowDialog();
        }
    }
}
