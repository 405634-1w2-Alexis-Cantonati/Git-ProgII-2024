using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_01.Dominio
{
    public class Articulo
    {
        public int IdArt { get; set; }
        public string Nombre { get; set; }
        public int PrecioUnitario { get; set; }

        public Articulo(int idArt, string nombre, int precioUnitario)
        {
            IdArt = idArt;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
        }
        public Articulo()
        {
            IdArt = 0;
            Nombre = "";
            PrecioUnitario = 0;
        }
    }
}
