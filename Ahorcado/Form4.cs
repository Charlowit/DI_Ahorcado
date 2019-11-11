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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string palabra = textBox1.Text;
            int tamaño = Form2.Palabras.Length;
            if (palabra.Length <= 15)
            {
                Form2.Palabras[tamaño-1] = palabra;
                Form1 ventanajuego = new Form1();
                ventanajuego.Visible = true;
                this.Visible = false;
            }
            else {
                MessageBox.Show("No es posible agregar la palabra, mide mas de 12 letras");
            }
        }
    }
}
