using Suite_de_Videojuegos.Datos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Suite_de_Videojuegos.Forms
{
    public partial class FormHistorial : Form
    {
        PartidaDAO dao = new PartidaDAO();

        public FormHistorial()
        {
            InitializeComponent();

            EstilizarFormulario();

            CrearBotonVolver();

            CargarHistorial();
        }

        private void FormHIstorial_Load(object sender, EventArgs e)
        {

        }

        private void EstilizarFormulario()
        {
            this.BackColor = Color.FromArgb(20, 20, 75);

            btnActualizar.BackColor = Color.FromArgb(40, 150, 230);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnActualizar.Cursor = Cursors.Hand;

            btnActualizar.MouseEnter += (sender, e) =>
            {
                btnActualizar.BackColor = Color.FromArgb(41, 128, 185);
            };

            btnActualizar.MouseLeave += (sender, e) =>
            {
                btnActualizar.BackColor = Color.FromArgb(52, 152, 219);
            };

            dgvHistorial.BackgroundColor = Color.FromArgb(30, 30, 45);
            dgvHistorial.BorderStyle = BorderStyle.None;
            dgvHistorial.EnableHeadersVisualStyles = false;

            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 152, 219);

            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvHistorial.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvHistorial.DefaultCellStyle.BackColor =
                Color.FromArgb(45, 45, 65);

            dgvHistorial.DefaultCellStyle.ForeColor =
                Color.White;

            dgvHistorial.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(41, 128, 185);

            dgvHistorial.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvHistorial.GridColor =
                Color.FromArgb(70, 70, 90);

            dgvHistorial.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CrearBotonVolver()
        {
            Button btnVolver = new Button();

            btnVolver.Text = "⬅ Volver al menú";
            btnVolver.Width = btnActualizar.Width;
            btnVolver.Height = btnActualizar.Height;
            btnVolver.Left = btnActualizar.Left;
            btnVolver.Top =
                btnActualizar.Top +
                btnActualizar.Height +
                10;

            btnVolver.BackColor = Color.FromArgb(50, 160, 230);
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

        private void CargarHistorial()
        {
            dgvHistorial.DataSource = dao.ObtenerPartidas();
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void dgvHistorial_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {

        }
    }
}
