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
    public partial class Form2 : Form
    {
        char[] PalabrasAdivinadas;
        int Oportunidades;
        char[] PalabraSeleccionada;
        char[] Alfabeto;
        public static string[] Palabras = new string[] {"diclofenaco", "botella", "monitor", "perone", "teclado", "lorazepam", "altavoces", "impresora", "lapicero" };
        int valor = 0;
        public Form2(int i)
        {
            InitializeComponent();
            this.valor = i;
        }

        public void Compara(object sender, EventArgs e) {

            bool encontrado = false;
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Enabled = false;

            for (int indiceRevisar = 0; indiceRevisar < PalabrasAdivinadas.Length; indiceRevisar++) {
                if(PalabrasAdivinadas[indiceRevisar] == Char.Parse(btn.Text))
                {
                    Button tbx = this.Controls.Find("Adivinado" + indiceRevisar, true).FirstOrDefault() as Button;
                    tbx.Text = PalabrasAdivinadas[indiceRevisar].ToString();
                    PalabrasAdivinadas[indiceRevisar].ToString();
                    encontrado = true;
                }
            }

            //Verificar si todas las letras estan al descubierto
            bool ganaste = false;
            String textoAnalizar = "";
            String palabra = "";
            for (int indiceAnalizadorGanador = 0; indiceAnalizadorGanador < PalabrasAdivinadas.Length; indiceAnalizadorGanador++) {
                Button tbx = this.Controls.Find("Adivinado" + indiceAnalizadorGanador, true).FirstOrDefault() as Button;
                palabra += PalabrasAdivinadas[indiceAnalizadorGanador].ToString();
                textoAnalizar += tbx.Text;
            }
            if (textoAnalizar == palabra)
            {
                ganaste = true;
            }

            if (ganaste)
            {
                MessageBox.Show("!Has Ganado!");
                btnIniciarJuego.Image = Properties.Resources.start;
                flFichasDeJuego.Enabled = false;
            }
            if (encontrado == false) {
                Oportunidades += 1;
                if (Oportunidades == 1)
                {
                    pictureBox2.Visible = true;
                }
                else if (Oportunidades == 2) {
                    pictureBox3.Visible = true;
                }
                else if (Oportunidades == 3)
                {
                    pictureBox4.Visible = true;
                }
                else if (Oportunidades == 4)
                {
                    pictureBox5.Visible = true;
                }
                else if (Oportunidades == 5)
                {
                    pictureBox6.Visible = true;
                }

                if (Oportunidades == 6) {
                    lblMensaje.Visible = true;
                    pictureBox7.Visible = true;
                    for (int IndiceValorLetra = 0; IndiceValorLetra < PalabraSeleccionada.Length; IndiceValorLetra++) {
                        Button btnLetra = this.Controls.Find("Adivinado" + IndiceValorLetra, true).FirstOrDefault() as Button;
                        btnLetra.Text = btnLetra.Tag.ToString();
                    }
                    //Desactivando las letras del juego ya que ha perdido
                    flFichasDeJuego.Enabled = false;
                    btnIniciarJuego.Image = Properties.Resources.start;
                }
            }
        }
        
        public void IniciarJuego(int Argumento)
        {

            flFichasDeJuego.Controls.Clear();
            flFichasDeJuego.Enabled = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            lblMensaje.Visible = false;
            Oportunidades = 0;
            btnIniciarJuego.Image = Properties.Resources.jugando;
            Alfabeto = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ".ToCharArray();

            Random random = new Random();
            int IndicePalabraSeleccionada = random.Next(0, Palabras.Length);
            PalabraSeleccionada = Palabras[IndicePalabraSeleccionada].ToUpper().ToCharArray();
            PalabrasAdivinadas = PalabraSeleccionada;


            //Cargando le alfabeto en el fl
            foreach (char LetraAlfabeto in Alfabeto) {

                Button btnLetra = new Button();
                btnLetra.Tag = "";
                btnLetra.Text = LetraAlfabeto.ToString();
                btnLetra.Width = 60;
                btnLetra.Height = 40;
                btnLetra.Click += Compara;
                btnLetra.ForeColor = Color.White;
                btnLetra.Font = new Font(btnLetra.Font.Name, 15, FontStyle.Bold);
                btnLetra.BackgroundImageLayout = ImageLayout.Center;
                btnLetra.BackColor = Color.Black;
                btnLetra.Name = LetraAlfabeto.ToString();
                flFichasDeJuego.Controls.Add(btnLetra);

            }
            flPalabra.Controls.Clear();

            //Palabra elegida aletoriamente para adivinarla
            for (int IndiceValorLetra = 0; IndiceValorLetra < PalabraSeleccionada.Length; IndiceValorLetra++)
            {

                Button Letra = new Button();
                Letra.Tag = PalabraSeleccionada[IndiceValorLetra].ToString();
                Letra.Width = 46;
                Letra.Height = 70;
                Letra.Text = "-";
                Letra.ForeColor = Color.Purple;
                Letra.Font = new Font(Letra.Font.Name, 32, FontStyle.Bold);
                Letra.BackgroundImageLayout = ImageLayout.Center;
                Letra.BackColor = Color.White;
                Letra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                Letra.Name = "Adivinado" + IndiceValorLetra.ToString();
                flPalabra.Controls.Add(Letra);
            }
            if (Argumento == 1)
            {
                Random r1 = new Random();
                int aleatorio1 = r1.Next(0, PalabraSeleccionada.Length);
                int aleatorio2 = r1.Next(0, PalabraSeleccionada.Length);
                if (aleatorio1 == aleatorio2)
                {
                    aleatorio2 = r1.Next(0, PalabraSeleccionada.Length);
                }
                for (int indiceRevisar = 0; indiceRevisar < PalabraSeleccionada.Length; indiceRevisar++)
                {

                    if (PalabraSeleccionada[indiceRevisar].ToString() == PalabraSeleccionada[aleatorio1].ToString() )
                    {
                        Button tbx = this.Controls.Find("Adivinado" + indiceRevisar, true).FirstOrDefault() as Button;
                        tbx.Text = PalabraSeleccionada[aleatorio1].ToString();
                    }
                    if (PalabraSeleccionada[indiceRevisar].ToString() == PalabraSeleccionada[aleatorio2].ToString())
                    {
                        Button tbx = this.Controls.Find("Adivinado" + indiceRevisar, true).FirstOrDefault() as Button;
                        tbx.Text = PalabraSeleccionada[aleatorio2].ToString();
                    }
                }
            }
            else if (Argumento == 2)
            {
                Random r1 = new Random();

                int aleatorio1 = r1.Next(0, PalabraSeleccionada.Length);

                for (int indiceRevisar = 0; indiceRevisar < PalabraSeleccionada.Length; indiceRevisar++)
                {

                    if (PalabraSeleccionada[indiceRevisar].ToString() == PalabraSeleccionada[aleatorio1].ToString())
                    {
                        Button tbx = this.Controls.Find("Adivinado" + indiceRevisar, true).FirstOrDefault() as Button;
                        tbx.Text = PalabraSeleccionada[aleatorio1].ToString();
                    }
                }
            }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            IniciarJuego(valor);
        }

        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            IniciarJuego(valor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ventanajuego = new Form1();
            ventanajuego.Visible = true;
            this.Visible = false;

        }
    }
}
