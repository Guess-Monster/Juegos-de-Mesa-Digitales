using Suite_de_Videojuegos.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Suite_de_Videojuegos.Datos;
using Suite_de_Videojuegos.Entidades;

namespace Suite_de_Videojuegos.Forms
{
    public partial class FormTicTacToe : Form
    {
        TicTacToeLogica juego = new TicTacToeLogica();

        PartidaDAO partidaDAO = new PartidaDAO();

        MovimientoDAO movimientoDAO = new MovimientoDAO();

        int idPartida = 0;

        int turnoNumero = 1;
        public FormTicTacToe()
        {
            InitializeComponent();

            AsignarEventos();

            Partida partida = new Partida();

            partida.Juego = "TicTacToe";

            partida.Jugador1 = "Jugador X";

            partida.Jugador2 = "Jugador O";

            partida.Ganador = "";

            idPartida = partidaDAO.GuardarPartida(partida);
        }

        private void FormTicTacToe_Load(object sender, EventArgs e)
        {

        }

        private void AsignarEventos()
        {
            btn1.Click += Movimiento_Click;
            btn2.Click += Movimiento_Click;
            btn3.Click += Movimiento_Click;

            btn4.Click += Movimiento_Click;
            btn5.Click += Movimiento_Click;
            btn6.Click += Movimiento_Click;

            btn7.Click += Movimiento_Click;
            btn8.Click += Movimiento_Click;
            btn9.Click += Movimiento_Click;
        }

       private void Movimiento_Click(object? sender, EventArgs e)
        {
            if (sender is not Button boton)
                return;

            if (boton.Text != "")
                return;

            boton.Text = juego.Turno;

            Movimiento movimiento = new Movimiento();

            movimiento.IdPartida = idPartida;

            movimiento.Jugador = juego.Turno;

            movimiento.MovimientoRealizado = boton.Name;

            movimiento.NumeroTurno = turnoNumero;

            movimientoDAO.GuardarMovimiento(movimiento);

            turnoNumero++;

            string[] tablero =
            {
                btn1.Text,
                btn2.Text,
                btn3.Text,

                btn4.Text,
                btn5.Text,
                btn6.Text,

                btn7.Text,
                btn8.Text,
                btn9.Text
            };

            if (juego.HayGanador(tablero))
            {
                lblResultado.Text =
                    "Ganó el jugador " + juego.Turno;

                Partida partidaFinal = new Partida();

                partidaDAO.ActualizarGanador(idPartida,juego.Turno);

                partidaFinal.IdPartida = idPartida;

                DeshabilitarBotones();

                return;
            }

            if (tablero.All(x => x != ""))
            {
                lblResultado.Text = "Empate";
                return;
            }

            juego.CambiarTurno();

            lblTurno.Text =
                "Turno: " + juego.Turno;
        }

        private void DeshabilitarBotones()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;

            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;

            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        private void HabilitarBotones()
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;

            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;

            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
        }

        private void btnReiniciar_Click_1(object? sender, EventArgs e)
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

            juego.Turno = "X";

            lblTurno.Text = "Turno: X";

            lblResultado.Text = "";

            HabilitarBotones();
        }
    }
}

