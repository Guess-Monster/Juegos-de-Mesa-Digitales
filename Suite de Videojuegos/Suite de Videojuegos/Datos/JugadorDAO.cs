using MySql.Data.MySqlClient;
using Suite_de_Videojuegos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Suite_de_Videojuegos.Datos
{
    public class JugadorDAO
    {
        ConexionBD conexionBD =
            new ConexionBD();

        public void InsertarJugador(Jugador jugador)
        {
            using (MySqlConnection conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string query ="INSERT INTO Jugadores(Nombre) " +"VALUES(@Nombre)";

                MySqlCommand cmd = new MySqlCommand(query,conexion);

                cmd.Parameters.AddWithValue("@Nombre",jugador.Nombre);

                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarJugador(int id,string nombre)
        {
            using (MySqlConnection conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string query ="UPDATE Jugadores " +"SET Nombre=@Nombre " +"WHERE IdJugador=@Id";

                MySqlCommand cmd = new MySqlCommand(query,conexion);

                cmd.Parameters.AddWithValue("@Nombre",nombre);

                cmd.Parameters.AddWithValue("@Id",id);

                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarJugador(int id)
        {
            using (MySqlConnection conexion =
                conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string query = "DELETE FROM Jugadores " + "WHERE IdJugador=@Id";

                MySqlCommand cmd =new MySqlCommand(query,conexion);

                cmd.Parameters.AddWithValue("@Id",id);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerJugadores()
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string query = "SELECT * FROM Jugadores";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(query,conexion);

                adaptador.Fill(tabla);
            }

            return tabla;
        }

    }
}
