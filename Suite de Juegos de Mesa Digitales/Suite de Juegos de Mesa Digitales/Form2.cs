using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suite_de_Juegos_de_Mesa_Digitales
{
    public partial class frm2 : Form
    {
        string JugadorX = "";
        string JugadorO = "";
        bool cambio = true;
        int empate = 0;
        int ganadasX = 0;
        int ganadasO = 0;
        public frm2()
        {
            InitializeComponent();
        }

        private void frm2_Load(object sender, EventArgs e)
        {
            OnOffBtn(false);
        }

        private void OnOffBtn(bool onoff)
        {
            btn1.Enabled = onoff;
            btn2.Enabled = onoff;
            btn3.Enabled = onoff;
            btn4.Enabled = onoff;
            btn5.Enabled = onoff;
            btn6.Enabled = onoff;
            btn7.Enabled = onoff;
            btn8.Enabled = onoff;
            btn9.Enabled = onoff;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            if (txtJugador1.Text == "" && txtJugador2.Text == "")
            {
                MessageBox.Show("El nombre de los jugadores no debe estar vacio", "Nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtJugador1.Text == "")
                {
                    MessageBox.Show("El nombre del jugador 1 no debe estar vacio", "Nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (txtJugador2.Text == "")
                {
                    MessageBox.Show("El nombre del jugador 2 no debe estar vacio", "Nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (txtJugador1.Text != "" && txtJugador2.Text != "")
            {
                if (rdbX1.Checked && rdbO2.Checked)
                {
                    JugadorX = txtJugador1.Text;
                    JugadorO = txtJugador2.Text;
                    rdbO1.Enabled = false;
                    rdbX2.Enabled = false;
                    Playgame();
                }
                if (rdbO1.Checked && rdbX2.Checked)
                {
                    JugadorX = txtJugador2.Text;
                    JugadorO = txtJugador1.Text;
                    rdbX1.Enabled = false;
                    rdbO2.Enabled = false;
                    Playgame();
                }

                if (rdbX1.Checked && rdbX2.Checked)
                {
                    MessageBox.Show("Solo un jugador puede seleccionar la letra X", "Vuelve a escoger la letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (rdbO1.Checked && rdbO2.Checked)
                {
                    MessageBox.Show("Solo un jugador puede seleccionar la letra O", "Vuelve a escoger la letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (rdbX1.Checked == false && rdbO1.Checked == false || rdbX2.Checked == false && rdbO2.Checked == false)
                {
                    MessageBox.Show("Los jugadores deben seleccionar una letra", "Vuelve a escoger la letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Playgame()
        {
            lblJugador1.Text = txtJugador1.Text;
            lblJugador2.Text = txtJugador2.Text;

            groupBox1.Text = "Marcador";

            btnLimpiar.Visible = true;
            btnReiniciar.Visible = true;

            btnIniciar.Visible = false;
            txtJugador1.Visible = false;
            txtJugador2.Visible = false;

            MessageBox.Show("Empieza " + JugadorX, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OnOffBtn(true);
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (cambio)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            cambio = !cambio;
            b.Enabled = false;

            Partida();

        }

        private void Partida()
        {
            if ((btn1.Text == btn2.Text) && (btn2.Text == btn3.Text) && (!btn1.Enabled))
            { Validacion(btn1); }
            else if ((btn4.Text == btn5.Text) && (btn5.Text == btn6.Text) && (!btn3.Enabled))
            { Validacion(btn4); }
            else if ((btn7.Text == btn8.Text) && (btn8.Text == btn9.Text) && (!btn7.Enabled))
            { Validacion(btn7); }

            if ((btn1.Text == btn4.Text) && (btn4.Text == btn7.Text) && (!btn1.Enabled))
            { Validacion(btn1); }
            if ((btn2.Text == btn5.Text) && (btn5.Text == btn8.Text) && (!btn2.Enabled))
            { Validacion(btn2); }
            if ((btn3.Text == btn6.Text) && (btn6.Text == btn9.Text) && (!btn3.Enabled))
            { Validacion(btn3); }

            if ((btn1.Text == btn5.Text) && (btn5.Text == btn9.Text) && (!btn1.Enabled))
            { Validacion(btn1); }
            else if ((btn3.Text == btn5.Text) && (btn5.Text == btn7.Text) && (!btn3.Enabled))
            { Validacion(btn3); }

            empate++;
            if (empate == 9)
            {
                MessageBox.Show("Es un empate", "Empate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                OnOffBtn(true);
                empate = 0;

            }
        }
        public void Validacion(Button b)
        {
            empate = -1;
            if (b.Text == "X")
            {
                MessageBox.Show("Gana " + JugadorX, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasX++;
            }
            else if (b.Text == "O")
            {
                MessageBox.Show("Gana " + JugadorO, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasO++;
            }

            if (rdbX1.Checked && rdbO2.Checked)
            {
                lblpuntosJugador1.Text = ganadasX.ToString();
                lblpuntosJugador2.Text = ganadasO.ToString();
            }

            if (rdbO1.Checked && rdbX2.Checked)
            {
                lblpuntosJugador2.Text = ganadasX.ToString();
                lblpuntosJugador1.Text = ganadasO.ToString();
            }
            Limpiar();
            OnOffBtn(true);
        }

        private void Limpiar()
        {
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            OnOffBtn(true);
            empate = 0;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Limpiar();
            OnOffBtn(false);
            btnLimpiar.Visible=false;
            btnReiniciar.Visible=false;

            btnIniciar.Visible=true;
            txtJugador1.Visible=true;
            txtJugador2.Visible=true;

            JugadorX = "";
            JugadorO = "";
            ganadasX = 0;
            ganadasO = 0;
            cambio = true;

            lblpuntosJugador1.Text=0.ToString();
            lblpuntosJugador2.Text=0.ToString();

            lblJugador1.Text = "";
            lblJugador2.Text = "";

            rdbO1.Enabled = true;
            rdbX2.Enabled = true;
            rdbO2.Enabled = true;
            rdbX1.Enabled = true;

            rdbX1.Checked = false;
            rdbX2.Checked = false;
            rdbO1.Checked = false;
            rdbO2.Checked = false;

            groupBox1.Text = "Introduzca los nombres de los jugadores";

        }
    }
}