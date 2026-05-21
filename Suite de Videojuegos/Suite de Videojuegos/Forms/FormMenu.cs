using Suite_de_Videojuegos.Datos;
using Suite_de_Videojuegos.Forms;

namespace Suite_de_Videojuegos
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }


        private void btnTicTacToe_Click(object sender, EventArgs e)
        {
            FormTicTacToe ventana = new FormTicTacToe();

            ventana.Show();
        }

        private void btnDamas_Click(object sender, EventArgs e)
        {
            FormDamas ventana = new FormDamas();
            ventana.Show();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            FormConexion ventana = new FormConexion();
            ventana.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial ventana = new FormHistorial();
            ventana.Show();
        }
    }
}
