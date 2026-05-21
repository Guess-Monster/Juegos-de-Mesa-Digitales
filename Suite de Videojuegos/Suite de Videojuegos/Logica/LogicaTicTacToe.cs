using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suite_de_Videojuegos.Logica
{
    public class TicTacToeLogica
    {
        public string Turno { get; set; } = "X";

        public bool HayGanador(string[] tablero)
        {
            return
                (tablero[0] == tablero[1] &&
                 tablero[1] == tablero[2] &&
                 tablero[0] != "")

            ||

                (tablero[3] == tablero[4] &&
                 tablero[4] == tablero[5] &&
                 tablero[3] != "")

            ||

                (tablero[6] == tablero[7] &&
                 tablero[7] == tablero[8] &&
                 tablero[6] != "")

            ||

                (tablero[0] == tablero[3] &&
                 tablero[3] == tablero[6] &&
                 tablero[0] != "")

            ||

                (tablero[1] == tablero[4] &&
                 tablero[4] == tablero[7] &&
                 tablero[1] != "")

            ||

                (tablero[2] == tablero[5] &&
                 tablero[5] == tablero[8] &&
                 tablero[2] != "")

            ||

                (tablero[0] == tablero[4] &&
                 tablero[4] == tablero[8] &&
                 tablero[0] != "")

            ||

                (tablero[2] == tablero[4] &&
                 tablero[4] == tablero[6] &&
                 tablero[2] != "");
        }

        public void CambiarTurno()
        {
            if (Turno == "X")
                Turno = "O";
            else
                Turno = "X";
        }
    }
    internal class LogicaTicTacToe
    {

    }
}
