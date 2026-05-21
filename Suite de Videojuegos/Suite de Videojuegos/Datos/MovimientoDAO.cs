using MySql.Data.MySqlClient;
using Suite_de_Videojuegos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suite_de_Videojuegos.Datos
{
    public class MovimientoDAO
    {
        ConexionBD conexionBD = new ConexionBD();

        public void GuardarMovimiento(Movimiento movimiento)
        {
            using (MySqlConnection conexion =
                conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string query =
                "INSERT INTO Movimientos " + "(IdPartida, Jugador, Movimiento, NumeroTurno) " + "VALUES " + "(@IdPartida, @Jugador, @Movimiento, @NumeroTurno)";

                MySqlCommand cmd = new MySqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@IdPartida",movimiento.IdPartida);

                cmd.Parameters.AddWithValue("@Jugador", movimiento.Jugador);

                cmd.Parameters.AddWithValue("@Movimiento", movimiento.MovimientoRealizado);

                cmd.Parameters.AddWithValue("@NumeroTurno", movimiento.NumeroTurno);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
