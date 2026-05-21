using Suite_de_Videojuegos.Datos;
using Suite_de_Videojuegos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suite_de_Videojuegos.Forms
{
    public partial class FormJugadores : Form
    {
        JugadorDAO dao = new JugadorDAO();

        int idSeleccionado = 0;
        public FormJugadores()
        {
            InitializeComponent();

            CargarJugadores();
        }

        private void FormJugadores_Load(object sender, EventArgs e)
        {

        }

        private void CargarJugadores()
        {
            dgvJugadores.DataSource = dao.ObtenerJugadores();
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            Jugador jugador = new Jugador();

            jugador.Nombre = txtNombre.Text;

            dao.InsertarJugador(jugador);

            CargarJugadores();

            txtNombre.Clear();
        }

        private void dgvJugadores_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvJugadores.Rows[e.RowIndex].Cells["IdJugador"].Value);

                txtNombre.Text = dgvJugadores.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            dao.ActualizarJugador(idSeleccionado, txtNombre.Text);

            CargarJugadores();

            txtNombre.Clear();
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            dao.EliminarJugador(
                idSeleccionado);

            CargarJugadores();

            txtNombre.Clear();
        }

        private void btnListar_Click(object? sender, EventArgs e)
        {
            CargarJugadores();
        }

        
    }
}

