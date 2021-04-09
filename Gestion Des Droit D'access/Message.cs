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
    public partial class Message : Form
    {
        public string Titleq, req, conString, response;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move)
            {
                this.Location = new Point(this.Location.X + (e.X - MouseX), this.Location.Y + (e.Y - MouseY));
            }
        }

        public void Set(string Messagex, string Title)
        {
            Mess.Text = Messagex;
            label1.Text = Title;
            Titleq = Title;
            if (Title == "Erreur")
            {
                panel1.BackColor = ColorTranslator.FromHtml("178, 2, 2");
                panel2.BackColor = ColorTranslator.FromHtml("69, 35, 35");
                this.BackColor = ColorTranslator.FromHtml("81, 41, 41");
                button5.BackColor = ColorTranslator.FromHtml("81, 41, 41");
                button5.FlatAppearance.BorderColor = ColorTranslator.FromHtml("178, 2, 2");
                Mess.BackColor = panel2.BackColor;
                button5.Text = "OK";
            }
            else if(Title == "Confirmation")
            {
                panel1.BackColor = ColorTranslator.FromHtml("178, 174, 2");
                panel2.BackColor = ColorTranslator.FromHtml("67, 69, 35");
                this.BackColor = ColorTranslator.FromHtml("80, 81, 41");
                button5.BackColor = ColorTranslator.FromHtml("80, 81, 41");
                button5.FlatAppearance.BorderColor = ColorTranslator.FromHtml("178, 174, 2");
                Mess.BackColor = panel2.BackColor;
                button5.Text = "Confirmer";
            }
            else if(Title == "Success")
            {
                panel1.BackColor = ColorTranslator.FromHtml("36, 178, 2");
                panel2.BackColor = ColorTranslator.FromHtml("38, 69, 35");
                this.BackColor = ColorTranslator.FromHtml("41, 81, 41");
                button5.BackColor = ColorTranslator.FromHtml("41, 81, 41");
                button5.FlatAppearance.BorderColor = ColorTranslator.FromHtml("36, 178, 2");
                Mess.BackColor = panel2.BackColor;
                button5.Text = "OK";
            }
            else
            {
                panel1.BackColor = ColorTranslator.FromHtml("2, 99, 178");
                panel2.BackColor = ColorTranslator.FromHtml("35, 48, 69");
                this.BackColor = ColorTranslator.FromHtml("41, 56, 81");
                button5.BackColor = ColorTranslator.FromHtml("41, 56, 81");
                button5.FlatAppearance.BorderColor = ColorTranslator.FromHtml("2, 99, 178");
                Mess.BackColor = panel2.BackColor;
                button5.Text = "OK";
            }
            button1.BackColor = panel1.BackColor;
        }

        public Message()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(button5.Text == "OK")
            {
                this.Close();
            }else
            {
                response = "ok";
                this.Close();
            }
        }
    }
}
