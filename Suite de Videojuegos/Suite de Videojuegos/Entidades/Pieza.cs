using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suite_de_Videojuegos.Entidades
{

    public class Pieza
    {
        public string Color { get; set; }

        public bool Reina { get; set; }

        public Pieza(string color)
        {
            Color = color;
            Reina = false;
        }
    }


}
