using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suite_de_Videojuegos.Entidades
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }

        public int IdPartida { get; set; }

        public string Jugador { get; set; }

        public string MovimientoRealizado { get; set; }

        public int NumeroTurno { get; set; }
    }
}
