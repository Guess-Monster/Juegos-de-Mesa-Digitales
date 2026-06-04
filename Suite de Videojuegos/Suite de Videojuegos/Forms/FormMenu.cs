using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Suite_de_Videojuegos.Datos;
using Suite_de_Videojuegos.Forms;

namespace Suite_de_Videojuegos
{
    public partial class FormMenu : Form
    {
        private readonly Color ColorNormal = Color.FromArgb(52, 152, 219);
        private readonly Color ColorHover = Color.FromArgb(41, 128, 185);
        private readonly Color ColorSalir = Color.FromArgb(231, 76, 60);
        private readonly Color ColorSalirHover = Color.FromArgb(192, 57, 43);

        private Label? lblTotalPartidas;
        private Label? lblTicTacToe;
        private Label? lblDamas;
        private Label? lblEmpates;
        private Label? lblHora;
        private Label? lblRanking;

        private Button? btnActualizar;

        private StatusStrip? statusStripMenu;
        private ToolStripStatusLabel? toolEstadoBD;
        private ToolStripStatusLabel? toolPartidas;

        private System.Windows.Forms.Timer? timerReloj;

        public FormMenu()
        {
            InitializeComponent();

            ConfigurarFormulario();
            EstilizarBotonesExistentes();
            CrearDashboard();
            CrearStatusStrip();
            CrearReloj();

            CargarDashboard();
            VerificarBaseDatos();
        }

        private void ConfigurarFormulario()
        {
            this.BackColor = Color.FromArgb(30, 30, 45);
            this.StartPosition = FormStartPosition.CenterScreen;

            if (picLogo != null)
                picLogo.SizeMode = PictureBoxSizeMode.Zoom;

            if (lblTitulo != null)
            {
                lblTitulo.ForeColor = Color.White;
                lblTitulo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            }
        }

        private void EstilizarBotonesExistentes()
        {
            EstilizarBoton(btnTicTacToe, ColorNormal);
            EstilizarBoton(btnDamas, ColorNormal);
            EstilizarBoton(btnHistorial, ColorNormal);
            EstilizarBoton(btnBD, ColorNormal);
            EstilizarBoton(btnSalir, ColorSalir);

            ActivarHover(btnTicTacToe, ColorNormal, ColorHover);
            ActivarHover(btnDamas, ColorNormal, ColorHover);
            ActivarHover(btnHistorial, ColorNormal, ColorHover);
            ActivarHover(btnBD, ColorNormal, ColorHover);
            ActivarHover(btnSalir, ColorSalir, ColorSalirHover);

            btnTicTacToe.Text = "🎮 TicTacToe";
            btnDamas.Text = "♟️ Damas";
            btnHistorial.Text = "📜 Historial";
            btnBD.Text = "🗄 Base de Datos";
            btnSalir.Text = "❌ Salir";
        }

        private void CrearDashboard()
        {
            Panel panelDashboard = new Panel();

            panelDashboard.Name = "panelDashboard";
            panelDashboard.BackColor = Color.FromArgb(45, 45, 65);
            panelDashboard.Width = 320;
            panelDashboard.Height = 260;
            panelDashboard.Left = this.ClientSize.Width - panelDashboard.Width - 40;
            panelDashboard.Top = 140;
            panelDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Label lblTituloDashboard = new Label();

            lblTituloDashboard.Text = "📊 Dashboard";
            lblTituloDashboard.ForeColor = Color.White;
            lblTituloDashboard.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTituloDashboard.AutoSize = false;
            lblTituloDashboard.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloDashboard.Width = panelDashboard.Width;
            lblTituloDashboard.Height = 45;
            lblTituloDashboard.Top = 10;

            lblTotalPartidas = CrearLabelDashboard("🎮 Total de partidas: 0", 65);
            lblTicTacToe = CrearLabelDashboard("⭕ Partidas TicTacToe: 0", 95);
            lblDamas = CrearLabelDashboard("♟️ Partidas Damas: 0", 125);
            lblEmpates = CrearLabelDashboard("🤝 Empates: 0", 155);
            lblRanking = CrearLabelDashboard("🏆 Mejor jugador: Sin datos", 185);

            lblRanking.ForeColor = Color.Gold;

            btnActualizar = new Button();

            btnActualizar.Text = "🔄 Actualizar";
            btnActualizar.Width = 180;
            btnActualizar.Height = 38;
            btnActualizar.Left = (panelDashboard.Width - btnActualizar.Width) / 2;
            btnActualizar.Top = 215;

            EstilizarBoton(btnActualizar, ColorNormal);
            ActivarHover(btnActualizar, ColorNormal, ColorHover);

            btnActualizar.Click += btnActualizar_Click;

            panelDashboard.Controls.Add(lblTituloDashboard);
            panelDashboard.Controls.Add(lblTotalPartidas);
            panelDashboard.Controls.Add(lblTicTacToe);
            panelDashboard.Controls.Add(lblDamas);
            panelDashboard.Controls.Add(lblEmpates);
            panelDashboard.Controls.Add(lblRanking);
            panelDashboard.Controls.Add(btnActualizar);

            this.Controls.Add(panelDashboard);
            panelDashboard.BringToFront();
        }

        private Label CrearLabelDashboard(string texto, int top)
        {
            Label label = new Label();

            label.Text = texto;
            label.ForeColor = Color.White;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.AutoSize = false;
            label.Width = 290;
            label.Height = 28;
            label.Left = 20;
            label.Top = top;
            label.BackColor = Color.Transparent;

            return label;
        }

        private void CrearStatusStrip()
        {
            statusStripMenu = new StatusStrip();

            statusStripMenu.BackColor = Color.FromArgb(45, 45, 65);

            toolEstadoBD = new ToolStripStatusLabel();
            toolPartidas = new ToolStripStatusLabel();

            toolEstadoBD.ForeColor = Color.White;
            toolPartidas.ForeColor = Color.White;

            toolEstadoBD.Text = "BD: Verificando...";
            toolPartidas.Text = "Partidas registradas: 0";

            statusStripMenu.Items.Add(toolEstadoBD);
            statusStripMenu.Items.Add(new ToolStripStatusLabel(" | "));
            statusStripMenu.Items.Add(toolPartidas);

            this.Controls.Add(statusStripMenu);
        }

        private void CrearReloj()
        {
            lblHora = new Label();

            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblHora.ForeColor = Color.White;
            lblHora.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblHora.AutoSize = false;
            lblHora.Width = 230;
            lblHora.Height = 30;
            lblHora.TextAlign = ContentAlignment.MiddleRight;
            lblHora.Left = this.ClientSize.Width - lblHora.Width - 40;
            lblHora.Top = 105;
            lblHora.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.Controls.Add(lblHora);
            lblHora.BringToFront();

            timerReloj = new System.Windows.Forms.Timer();
            timerReloj.Interval = 1000;
            timerReloj.Tick += timerReloj_Tick;
            timerReloj.Start();
        }

        private void timerReloj_Tick(object? sender, EventArgs e)
        {
            if (lblHora != null)
                lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();

            CargarDashboard();
            VerificarBaseDatos();

            MessageBox.Show(
                "Dashboard actualizado correctamente.",
                "Actualización",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void EstilizarBoton(Button boton, Color colorBase)
        {
            boton.BackColor = colorBase;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;
        }

        private void ActivarHover(Button boton, Color colorNormal, Color colorHover)
        {
            boton.MouseEnter += (sender, e) =>
            {
                boton.BackColor = colorHover;
            };

            boton.MouseLeave += (sender, e) =>
            {
                boton.BackColor = colorNormal;
            };
        }

        private void CargarDashboard()
        {
            if (lblTotalPartidas == null ||
                lblTicTacToe == null ||
                lblDamas == null ||
                lblEmpates == null ||
                lblRanking == null)
                return;

            try
            {
                ConexionBD bd = new ConexionBD();

                using (MySqlConnection conexion = bd.ObtenerConexion())
                {
                    conexion.Open();

                    int totalPartidas = EjecutarConteo(
                        conexion,
                        "SELECT COUNT(*) FROM Partidas");

                    int totalTicTacToe = EjecutarConteo(
                        conexion,
                        "SELECT COUNT(*) FROM Partidas WHERE Juego = 'TicTacToe'");

                    int totalDamas = EjecutarConteo(
                        conexion,
                        "SELECT COUNT(*) FROM Partidas WHERE Juego = 'Damas'");

                    int empates = EjecutarConteo(
                        conexion,
                        "SELECT COUNT(*) FROM Partidas WHERE Ganador = '' OR Ganador IS NULL OR Ganador = 'Empate'");

                    string mejorJugador = ObtenerMejorJugador(conexion);

                    lblTotalPartidas.Text = "🎮 Total de partidas: " + totalPartidas;
                    lblTicTacToe.Text = "⭕ Partidas TicTacToe: " + totalTicTacToe;
                    lblDamas.Text = "♟️ Partidas Damas: " + totalDamas;
                    lblEmpates.Text = "🤝 Empates: " + empates;
                    lblRanking.Text = "🏆 Mejor jugador: " + mejorJugador;

                    if (toolPartidas != null)
                        toolPartidas.Text = "Partidas registradas: " + totalPartidas;
                }
            }
            catch
            {
                lblTotalPartidas.Text = "🎮 Total de partidas: 0";
                lblTicTacToe.Text = "⭕ Partidas TicTacToe: 0";
                lblDamas.Text = "♟️ Partidas Damas: 0";
                lblEmpates.Text = "🤝 Empates: 0";
                lblRanking.Text = "🏆 Mejor jugador: Sin conexión";
            }
        }

        private int EjecutarConteo(MySqlConnection conexion, string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private string ObtenerMejorJugador(MySqlConnection conexion)
        {
            string query =
                "SELECT Ganador, COUNT(*) AS Victorias " +
                "FROM Partidas " +
                "WHERE Ganador IS NOT NULL " +
                "AND Ganador <> '' " +
                "AND Ganador <> 'Empate' " +
                "GROUP BY Ganador " +
                "ORDER BY Victorias DESC " +
                "LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(query, conexion);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return reader["Ganador"].ToString() +
                           " (" +
                           reader["Victorias"].ToString() +
                           " victorias)";
                }
            }

            return "Sin datos";
        }

        private void VerificarBaseDatos()
        {
            if (toolEstadoBD == null)
                return;

            try
            {
                ConexionBD bd = new ConexionBD();

                using (MySqlConnection conexion = bd.ObtenerConexion())
                {
                    conexion.Open();

                    toolEstadoBD.Text = "BD: Conectada ✔";
                    toolEstadoBD.ForeColor = Color.LightGreen;
                }
            }
            catch
            {
                toolEstadoBD.Text = "BD: Sin conexión ✖";
                toolEstadoBD.ForeColor = Color.Red;
            }
        }

        private void btnTicTacToe_Click(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();

            FormTicTacToe ventana = new FormTicTacToe();
            ventana.Show();
        }

        private void btnDamas_Click(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();

            FormDamas ventana = new FormDamas();
            ventana.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            SystemSounds.Exclamation.Play();
            Application.Exit();
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();

            FormConexion ventana = new FormConexion();
            ventana.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();

            FormHistorial ventana = new FormHistorial();
            ventana.Show();
        }

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
