using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suite_de_Videojuegos.Entidades
{
    public class Partida
    {
        public int IdPartida { get; set; }

        public string Juego { get; set; }

        public string Jugador1 { get; set; }

        public string Jugador2 { get; set; }

        public string Ganador { get; set; }
    }
}
