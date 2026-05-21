using Suite_de_Videojuegos.Datos;
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
    public partial class FormHistorial : Form
    {
        PartidaDAO dao = new PartidaDAO();
        public FormHistorial()
        {
            InitializeComponent();

            CargarHistorial();
        }

        private void FormHIstorial_Load(object sender, EventArgs e)
        {

        }

        private void CargarHistorial()
        {
            dgvHistorial.DataSource = dao.ObtenerPartidas();
        }

        private void btnActualizar_Click(object? sender,EventArgs e)
        {
            CargarHistorial();
        }
    }
}

