using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form3 : Form
    {
        public string user = "admin";
        public string pass = "1234";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == user && textBox2.Text == pass)
            {
                Form4 ventanajuego = new Form4();
                ventanajuego.Visible = true;
                this.Visible = false;
            }
            else {
                MessageBox.Show("Contraseña o usuario incorrectos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ventanajuego = new Form1();
            ventanajuego.Visible = true;
            this.Visible = false;
        }
    }
}
