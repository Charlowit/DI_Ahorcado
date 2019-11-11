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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Form2 ventanajuego = new Form2(1);
                ventanajuego.Visible = true;
                this.Visible = false;
            }
            else if (radioButton2.Checked == true) {
                Form2 ventanajuego = new Form2(2);
                ventanajuego.Visible = true;
                this.Visible = false;
            }
            else if (radioButton3.Checked == true)
            {
                Form2 ventanajuego = new Form2(3);
                ventanajuego.Visible = true;
                this.Visible = false;
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void insertarNuevaPalabraToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 ventanajuego = new Form3();
            ventanajuego.Visible = true;
            this.Visible = false;
        }
    }
}
