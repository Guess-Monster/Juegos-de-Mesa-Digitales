using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suite_de_Videojuegos.Datos
{
    public class ConexionBD
    {
        private string conexionString =
        "server=localhost;" +
        "database=SuiteVideojuegos;" +
        "user=root;" +
        "password=root131;";

        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion =
                new MySqlConnection(conexionString);

            return conexion;
        }
    }
}
