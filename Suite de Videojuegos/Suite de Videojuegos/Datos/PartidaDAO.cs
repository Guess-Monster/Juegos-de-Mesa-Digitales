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
    public class PartidaDAO
    {
        ConexionBD conexionBD = new ConexionBD();

        public int GuardarPartida(Partida partida)
        {
            int idPartida = 0;

            using (MySqlConnection conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string query = "INSERT INTO Partidas " + "(Juego, Jugador1, Jugador2, Ganador) " + "VALUES " + "(@Juego, @Jugador1, @Jugador2, @Ganador); " + "SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@Juego", partida.Juego);

                cmd.Parameters.AddWithValue("@Jugador1", partida.Jugador1);

                cmd.Parameters.AddWithValue("@Jugador2", partida.Jugador2);

                cmd.Parameters.AddWithValue("@Ganador", partida.Ganador);

                idPartida = Convert.ToInt32(
                    cmd.ExecuteScalar());
            }

            return idPartida;
        }

        public DataTable ObtenerPartidas()
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string query = "SELECT * FROM Partidas";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);

                adaptador.Fill(tabla);
            }

            return tabla;
        }

        public void ActualizarGanador(int idPartida,string ganador)
            {
                using (MySqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    string query =
                        "UPDATE Partidas " +
                        "SET Ganador=@Ganador " +
                        "WHERE IdPartida=@IdPartida";

                    MySqlCommand cmd = new MySqlCommand( query,conexion);

                    cmd.Parameters.AddWithValue("@Ganador", ganador);

                    cmd.Parameters.AddWithValue("@IdPartida",idPartida);

                    cmd.ExecuteNonQuery();
                }
        }
    }
}