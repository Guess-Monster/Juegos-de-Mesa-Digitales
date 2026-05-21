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
    public partial class FormDamas : Form
    {
        DamasLogica juego = new DamasLogica();
        PartidaDAO partidaDAO =new PartidaDAO();

        MovimientoDAO movimientoDAO = new MovimientoDAO();

        int idPartida = 0;

        int turnoNumero = 1;

        Panel[,] casillas = new Panel[8, 8];

        Panel? casillaSeleccionada = null;
        public FormDamas()
        {
            InitializeComponent();

            CrearTablero();

            ColocarFichas();

            lblTurno.Text = "Turno: Rojo";

            Partida partida = new Partida();

            partida.Juego = "Damas";

            partida.Jugador1 = "Rojo";

            partida.Jugador2 = "Negro";

            partida.Ganador = "";

            idPartida =
                partidaDAO.GuardarPartida(
                    partida);
        }

        private void FormDamas_Load(object sender, EventArgs e)
        {

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

                    panel.Tag =
                        new Point(fila, columna);

                    if ((fila + columna) % 2 == 0)
                        panel.BackColor = Color.Beige;
                    else
                        panel.BackColor = Color.Brown;

                    panel.Click += Casilla_Click;

                    tablero.Controls.Add(panel,
                        columna,
                        fila);

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
                        CrearFicha(fila,
                            columna,
                            Color.Red);
                    }
                }
            }

            for (int fila = 5; fila < 8; fila++)
            {
                for (int columna = 0; columna < 8; columna++)
                {
                    if ((fila + columna) % 2 != 0)
                    {
                        CrearFicha(fila,
                            columna,
                            Color.Black);
                    }
                }
            }
        }

        private void CrearFicha(int fila, int columna, Color color)
        {
            Button ficha = new Button();

            ficha.Dock = DockStyle.Fill;

            ficha.FlatStyle = FlatStyle.Flat;

            ficha.FlatAppearance.BorderSize = 0;

            ficha.BackColor = color;

            ficha.Tag = new Entidades.Pieza(color == Color.Red? "Rojo": "Negro");

            ficha.Click += Ficha_Click;

            casillas[fila, columna].Controls.Add(ficha);
        }

        private void Ficha_Click(object? sender, EventArgs e)
        {
            if(sender is not Button ficha)
            return;

            if (juego.Turno == "Rojo" &&
                ficha.BackColor != Color.Red)
                return;

            if (juego.Turno == "Negro" &&
                ficha.BackColor != Color.Black)
                return;

            casillaSeleccionada = ficha.Parent as Panel;
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

            if (ficha.Tag is not Entidades.Pieza pieza)
                return;

            Color colorFicha = ficha.BackColor;

            if (casillaSeleccionada.Tag is not Point origen)
                return;

            if (destino.Tag is not Point nueva)
                return;

            int diferenciaFila = nueva.X - origen.X;

            int diferenciaColumna = Math.Abs(nueva.Y - origen.Y);

            bool movimientoComer = diferenciaFila == 2 || diferenciaFila == -2;


            if (!pieza.Reina)
            {
                if (colorFicha == Color.Red)
                {
                    if (diferenciaFila != 1 && diferenciaFila != 2)
                        return;

                    if (diferenciaColumna != 1 &&diferenciaColumna != 2)
                        return;
                }

                if (colorFicha == Color.Black)
                {
                    if (diferenciaFila != -1 && diferenciaFila != -2)
                        return;

                    if (diferenciaColumna != 1 && diferenciaColumna != 2)
                        return;
                }
            }
            else
            {
                if (Math.Abs(diferenciaFila) !=Math.Abs(diferenciaColumna))
                    return;
            }

            if (movimientoComer)
            {
                int filaMedia = (origen.X + nueva.X) / 2;

                int columnaMedia = (origen.Y + nueva.Y) / 2;

                Panel casillaMedia =casillas[filaMedia,columnaMedia];

                if (casillaMedia.Controls.Count > 0)
                {
                    casillaMedia.Controls.Clear();
                }
            }

            casillaSeleccionada.Controls.Clear();

            destino.Controls.Add(ficha);

            Movimiento movimiento =new Movimiento();

            movimiento.IdPartida = idPartida;

            movimiento.Jugador =juego.Turno;

            movimiento.MovimientoRealizado =$"{origen.X},{origen.Y} -> " + $"{nueva.X},{nueva.Y}";

            movimiento.NumeroTurno = turnoNumero;

            movimientoDAO.GuardarMovimiento(movimiento);

            turnoNumero++;

            string movimiento1 =$"[{juego.Turno}] " +$"{origen.X},{origen.Y} -> " +$"{nueva.X},{nueva.Y}";

            lstHistorial.Items.Add(movimiento);

            if (colorFicha == Color.Red & nueva.X == 7)
            {
                pieza.Reina = true;

                ficha.Text = "R";
            }

            if (colorFicha == Color.Black & nueva.X == 0)
            {
                pieza.Reina = true;

                ficha.Text = "R";
            }

            juego.CambiarTurno();

            lblTurno.Text = "Turno: " + juego.Turno;

            casillaSeleccionada = null;

            VerificarGanador();
        }

        private void btnReiniciar_Click_1(object sender, EventArgs e)
        {
            tablero.Controls.Clear();

            CrearTablero();

            ColocarFichas();

            juego.Turno = "Rojo";

            lblTurno.Text =
                "Turno: Rojo";

            lblResultado.Text = "";

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
                    Button ficha =
                        (Button)panel.Controls[0];

                    if (ficha.BackColor ==
                        Color.Red)
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
                lblResultado.Text ="Ganó Negro";

                partidaDAO.ActualizarGanador(idPartida,"Negro");

                tablero.Enabled = false;
            }

            if (negras == 0)
            {
                lblResultado.Text ="Ganó Rojo";

                partidaDAO.ActualizarGanador(idPartida,"Rojo");

                tablero.Enabled = false;
            }
        }
    }
}