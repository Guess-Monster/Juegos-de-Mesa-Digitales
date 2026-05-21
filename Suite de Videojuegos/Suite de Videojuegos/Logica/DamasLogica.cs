using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suite_de_Videojuegos.Logica
{
    public class DamasLogica
    {
        public string Turno { get; set; } = "Rojo";

        public void CambiarTurno()
        {
            if (Turno == "Rojo")
                Turno = "Negro";
            else
                Turno = "Rojo";
        }
    }
}
