using Suite_de_Videojuegos.Logica;
using System;
using System.Drawing;
using System.Windows.Forms;
using Suite_de_Videojuegos.Datos;
using Suite_de_Videojuegos.Entidades;

namespace Suite_de_Videojuegos.Forms
{
    public partial class FormDamas : Form
    {
        DamasLogica juego = new DamasLogica();

        PartidaDAO partidaDAO = new PartidaDAO();
        MovimientoDAO movimientoDAO = new MovimientoDAO();

        int idPartida = 0;
        int turnoNumero = 1;

        Panel[,] casillas = new Panel[8, 8];

        Panel? casillaSeleccionada = null;

        private readonly Color ColorRojoFicha = Color.FromArgb(231, 76, 60);
        private readonly Color ColorNegroFicha = Color.FromArgb(35, 35, 25);
        private readonly Color ColorCasillaClara = Color.FromArgb(195, 180, 215);
        private readonly Color ColorCasillaOscura = Color.FromArgb(85, 65, 35);

        public FormDamas()
        {
            InitializeComponent();

            EstilizarFormulario();

            CrearTablero();

            ColocarFichas();

            ConfigurarMensajeCentral();

            CrearBotonVolver();

            lblTurno.Text = "Turno: Rojo";

            lblCoordenadas.Text = "Coordenadas:";

            Partida partida = new Partida();

            partida.Juego = "Damas";
            partida.Jugador1 = "Rojo";
            partida.Jugador2 = "Negro";
            partida.Ganador = "";

            idPartida = partidaDAO.GuardarPartida(partida);
        }

        private void FormDamas_Load(object sender, EventArgs e)
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

        private void EstilizarFormulario()
        {
            this.BackColor = Color.FromArgb(30, 30, 45);

            tablero.BackColor = Color.FromArgb(45, 45, 65);

            lblTurno.ForeColor = Color.White;
            lblResultado.ForeColor = Color.Gold;
            lblCoordenadas.ForeColor = Color.White;

            lblTurno.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblResultado.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblCoordenadas.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            btnReiniciar.BackColor = Color.FromArgb(52, 152, 219);
            btnReiniciar.ForeColor = Color.White;
            btnReiniciar.FlatStyle = FlatStyle.Flat;
            btnReiniciar.FlatAppearance.BorderSize = 0;
            btnReiniciar.Cursor = Cursors.Hand;

            lstHistorial.BackColor = Color.FromArgb(45, 45, 65);
            lstHistorial.ForeColor = Color.White;
            lstHistorial.BorderStyle = BorderStyle.None;
            lstHistorial.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        private void ConfigurarMensajeCentral()
        {
            lblMensajeCentral.Visible = false;
            lblMensajeCentral.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblMensajeCentral.ForeColor = Color.Gold;
            lblMensajeCentral.TextAlign = ContentAlignment.MiddleCenter;
            lblMensajeCentral.BackColor = Color.Transparent;

            lblMensajeCentral.Left =
                tablero.Left + (tablero.Width - lblMensajeCentral.Width) / 2;

            lblMensajeCentral.Top =
                tablero.Top + (tablero.Height - lblMensajeCentral.Height) / 2;

            lblMensajeCentral.BringToFront();
        }

        private void CrearTablero()
        {
            tablero.Controls.Clear();

            for (int fila = 0; fila < 8; fila++)
            {
                for (int columna = 0; columna < 8; columna++)
                {
                    Panel panel = new Panel();

                    panel.Dock = DockStyle.Fill;
                    panel.Margin = new Padding(0);
                    panel.Tag = new Point(fila, columna);

                    if ((fila + columna) % 2 == 0)
                    {
                        panel.BackColor = ColorCasillaClara;
                    }
                    else
                    {
                        panel.BackColor = ColorCasillaOscura;
                    }

                    panel.Click += Casilla_Click;

                    tablero.Controls.Add(panel, columna, fila);

                    casillas[fila, columna] = panel;
                }
            }
        }

        private void ColocarFichas()
        {
            for (int fila = 0; fila < 3; fila++)
            {
                for (int columna = 0; columna < 8; columna++)
                {
                    if ((fila + columna) % 2 != 0)
                    {
                        CrearFicha(fila, columna, Color.Red);
                    }
                }
            }

            for (int fila = 5; fila < 8; fila++)
            {
                for (int columna = 0; columna < 8; columna++)
                {
                    if ((fila + columna) % 2 != 0)
                    {
                        CrearFicha(fila, columna, Color.Black);
                    }
                }
            }
        }

        private void CrearFicha(int fila, int columna, Color color)
        {
            Button ficha = new Button();

            ficha.Dock = DockStyle.Fill;
            ficha.FlatStyle = FlatStyle.Flat;
            ficha.FlatAppearance.BorderSize = 2;

            if (color == Color.Red)
            {
                ficha.FlatAppearance.BorderColor = Color.White;
            }
            else
            {
                ficha.FlatAppearance.BorderColor = Color.Black;
            }

            if (color == Color.Red)
            {
                ficha.BackColor = ColorRojoFicha;
                ficha.Tag = new Pieza("Rojo");
            }
            else
            {
                ficha.BackColor = ColorNegroFicha;
                ficha.Tag = new Pieza("Negro");
            }

            ficha.ForeColor = Color.White;
            ficha.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            ficha.Click += Ficha_Click;

            casillas[fila, columna].Controls.Add(ficha);
        }

        private void Ficha_Click(object? sender, EventArgs e)
        {
            if (sender is not Button ficha)
                return;

            if (juego.Turno == "Rojo" &&
                ficha.BackColor != ColorRojoFicha)
                return;

            if (juego.Turno == "Negro" &&
                ficha.BackColor != ColorNegroFicha)
                return;

            casillaSeleccionada = ficha.Parent as Panel;

            if (casillaSeleccionada != null &&
                casillaSeleccionada.Tag is Point punto)
            {
                lblCoordenadas.Text =
                    $"Ficha {juego.Turno}: {ObtenerCoordenada(punto.X, punto.Y)}";
            }
        }

        private void Casilla_Click(object? sender, EventArgs e)
        {
            if (casillaSeleccionada == null)
                return;

            if (sender is not Panel destino)
                return;

            if (destino.Controls.Count > 0)
                return;

            Button ficha = (Button)casillaSeleccionada.Controls[0];

            if (ficha.Tag is not Pieza pieza)
                return;

            if (casillaSeleccionada.Tag is not Point origen)
                return;

            if (destino.Tag is not Point nueva)
                return;

            Color colorFicha = ficha.BackColor;

            int diferenciaFila = nueva.X - origen.X;
            int diferenciaColumna = Math.Abs(nueva.Y - origen.Y);

            bool movimientoComer =
                diferenciaFila == 2 ||
                diferenciaFila == -2;

            if (!pieza.Reina)
            {
                if (colorFicha == ColorRojoFicha)
                {
                    if (diferenciaFila != 1 &&
                        diferenciaFila != 2)
                        return;

                    if (diferenciaColumna != 1 &&
                        diferenciaColumna != 2)
                        return;
                }

                if (colorFicha == ColorNegroFicha)
                {
                    if (diferenciaFila != -1 &&
                        diferenciaFila != -2)
                        return;

                    if (diferenciaColumna != 1 &&
                        diferenciaColumna != 2)
                        return;
                }
            }
            else
            {
                if (Math.Abs(diferenciaFila) != diferenciaColumna)
                    return;
            }

            if (movimientoComer)
            {
                int filaMedia = (origen.X + nueva.X) / 2;
                int columnaMedia = (origen.Y + nueva.Y) / 2;

                Panel casillaMedia = casillas[filaMedia, columnaMedia];

                if (casillaMedia.Controls.Count > 0)
                {
                    casillaMedia.Controls.Clear();
                }
            }

            casillaSeleccionada.Controls.Clear();

            destino.Controls.Add(ficha);

            string coordenadaOrigen =
                ObtenerCoordenada(origen.X, origen.Y);

            string coordenadaDestino =
                ObtenerCoordenada(nueva.X, nueva.Y);

            Movimiento movimiento = new Movimiento();

            movimiento.IdPartida = idPartida;
            movimiento.Jugador = juego.Turno;
            movimiento.MovimientoRealizado =
                $"{coordenadaOrigen} -> {coordenadaDestino}";
            movimiento.NumeroTurno = turnoNumero;

            movimientoDAO.GuardarMovimiento(movimiento);

            turnoNumero++;

            string movimientoHistorial =
                $"[{juego.Turno}] {coordenadaOrigen} -> {coordenadaDestino}";

            lstHistorial.Items.Add(movimientoHistorial);

            lblCoordenadas.Text =
                $"Último movimiento: {juego.Turno} {coordenadaOrigen} -> {coordenadaDestino}";

            if (colorFicha == ColorRojoFicha && nueva.X == 7)
            {
                pieza.Reina = true;
                ficha.Text = "👑";
                ficha.Font = new Font("Segoe UI Emoji", 16, FontStyle.Bold);
            }

            if (colorFicha == ColorNegroFicha && nueva.X == 0)
            {
                pieza.Reina = true;
                ficha.Text = "👑";
                ficha.Font = new Font("Segoe UI Emoji", 16, FontStyle.Bold);
            }

            juego.CambiarTurno();

            lblTurno.Text = "Turno: " + juego.Turno;

            casillaSeleccionada = null;

            VerificarGanador();
        }

        private string ObtenerCoordenada(int fila, int columna)
        {
            char letra = (char)('A' + columna);

            int numero = 8 - fila;

            return $"{letra}{numero}";
        }

        private void btnReiniciar_Click_1(object sender, EventArgs e)
        {
            tablero.Controls.Clear();

            CrearTablero();

            ColocarFichas();

            juego.Turno = "Rojo";

            lblTurno.Text = "Turno: Rojo";

            lblResultado.Text = "";

            lblMensajeCentral.Visible = false;

            lblCoordenadas.Text = "Coordenadas:";

            lstHistorial.Items.Clear();

            tablero.Enabled = true;
        }

        private void VerificarGanador()
        {
            int rojas = 0;
            int negras = 0;

            foreach (Panel panel in casillas)
            {
                if (panel.Controls.Count > 0)
                {
                    Button ficha = (Button)panel.Controls[0];

                    if (ficha.BackColor == ColorRojoFicha)
                    {
                        rojas++;
                    }
                    else
                    {
                        negras++;
                    }
                }
            }

            if (rojas == 0)
            {
                lblResultado.Text = "🏆 GANÓ NEGRO 🏆";

                lblMensajeCentral.Text = "🏆 GANÓ NEGRO 🏆";
                lblMensajeCentral.Visible = true;
                lblMensajeCentral.BringToFront();

                partidaDAO.ActualizarGanador(idPartida, "Negro");

                tablero.Enabled = false;
            }

            if (negras == 0)
            {
                lblResultado.Text = "🏆 GANÓ ROJO 🏆";

                lblMensajeCentral.Text = "🏆 GANÓ ROJO 🏆";
                lblMensajeCentral.Visible = true;
                lblMensajeCentral.BringToFront();

                partidaDAO.ActualizarGanador(idPartida, "Rojo");

                tablero.Enabled = false;
            }
        }
    }
}