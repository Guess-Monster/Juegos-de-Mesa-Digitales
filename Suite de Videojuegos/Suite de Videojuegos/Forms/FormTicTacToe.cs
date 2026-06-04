using Suite_de_Videojuegos.Logica;
using System;
using System.Drawing;
using System.Linq;
using System.Media;
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

            EstilizarTablero();

            ConfigurarMensajeCentral();

            CrearBotonVolver();

            Partida partida = new Partida();

            partida.Juego = "TicTacToe";
            partida.Jugador1 = "Jugador X";
            partida.Jugador2 = "Jugador O";
            partida.Ganador = "";

            idPartida = partidaDAO.GuardarPartida(partida);

            lblTurno.Text = "Turno: X";
        }

        private void FormTicTacToe_Load(object sender, EventArgs e)
        {

        }

        private void CrearBotonVolver()
        {
            Button btnVolver = new Button();

            btnVolver.Text = "⬅ Volver al menú";
            btnVolver.Width = btnReiniciar.Width;
            btnVolver.Height = btnReiniciar.Height;
            btnVolver.Left = btnReiniciar.Left;
            btnVolver.Top = btnReiniciar.Top + btnReiniciar.Height + 10;

            btnVolver.BackColor = Color.FromArgb(52, 152, 219);
            btnVolver.ForeColor = Color.White;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnVolver.Cursor = Cursors.Hand;

            btnVolver.MouseEnter += (sender, e) =>
            {
                btnVolver.BackColor = Color.FromArgb(41, 128, 185);
            };

            btnVolver.MouseLeave += (sender, e) =>
            {
                btnVolver.BackColor = Color.FromArgb(52, 152, 219);
            };

            btnVolver.Click += (sender, e) =>
            {
                this.Close();
            };

            this.Controls.Add(btnVolver);
            btnVolver.BringToFront();
        }

        private void EstilizarTablero()
        {
            Button[] botones =
            {
                btn1, btn2, btn3,
                btn4, btn5, btn6,
                btn7, btn8, btn9
            };

            foreach (Button b in botones)
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = new Font("Segoe UI", 24, FontStyle.Bold);
                b.BackColor = Color.FromArgb(45, 45, 65);
                b.ForeColor = Color.White;
            }

            btnReiniciar.BackColor = Color.FromArgb(52, 152, 219);
            btnReiniciar.ForeColor = Color.White;
            btnReiniciar.FlatStyle = FlatStyle.Flat;
            btnReiniciar.FlatAppearance.BorderSize = 0;
            btnReiniciar.Cursor = Cursors.Hand;

            this.BackColor = Color.FromArgb(30, 30, 45);

            lblTurno.ForeColor = Color.White;
            lblResultado.ForeColor = Color.White;
        }

        private void ConfigurarMensajeCentral()
        {
            lblMensajeCentral.Visible = false;
            lblMensajeCentral.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblMensajeCentral.ForeColor = Color.Gold;
            lblMensajeCentral.BackColor = Color.Transparent;
            lblMensajeCentral.TextAlign = ContentAlignment.MiddleCenter;

            lblMensajeCentral.Left =
                (this.ClientSize.Width - lblMensajeCentral.Width) / 2;

            lblMensajeCentral.Top =
                (this.ClientSize.Height - lblMensajeCentral.Height) / 2;
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

            if (juego.Turno == "X")
                boton.ForeColor = Color.FromArgb(46, 204, 113);
            else
                boton.ForeColor = Color.FromArgb(231, 76, 60);

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
                SystemSounds.Exclamation.Play();

                lblResultado.Text = "Ganó el jugador " + juego.Turno;

                lblMensajeCentral.Text = "🏆 GANÓ " + juego.Turno + " 🏆";
                lblMensajeCentral.Visible = true;
                lblMensajeCentral.BringToFront();

                partidaDAO.ActualizarGanador(idPartida, juego.Turno);

                DeshabilitarBotones();

                return;
            }

            if (tablero.All(x => x != ""))
            {
                SystemSounds.Hand.Play();

                lblResultado.Text = "Empate";

                lblMensajeCentral.Text = "🤝 EMPATE 🤝";
                lblMensajeCentral.Visible = true;
                lblMensajeCentral.BringToFront();

                return;
            }

            juego.CambiarTurno();

            lblTurno.Text = "Turno: " + juego.Turno;
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
            lblMensajeCentral.Visible = false;

            HabilitarBotones();
        }

        private void lblMensajeCentral_Click(object sender, EventArgs e)
        {

        }
    }
}
