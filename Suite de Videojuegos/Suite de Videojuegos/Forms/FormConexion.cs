using MySql.Data.MySqlClient;
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
    public partial class FormConexion : Form
    {
        public FormConexion()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionBD bd =
                    new ConexionBD();

                MySqlConnection conexion =
                    bd.ObtenerConexion();

                conexion.Open();

                MessageBox.Show(
                    "Conexión exitosa");

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}
    

