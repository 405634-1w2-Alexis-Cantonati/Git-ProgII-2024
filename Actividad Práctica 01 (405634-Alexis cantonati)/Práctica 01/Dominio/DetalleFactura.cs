using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_01.Dominio
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int idFactura { get; set; }
        public Articulo articulo { get; set; }
        public int Cantidad { get; set; }

        public DetalleFactura(int det, int fac,Articulo art, int can)
        {
            IdDetalle = det;
            idFactura = fac;
            articulo = art;
            Cantidad = can;
        }

        public DetalleFactura()
        {
            IdDetalle = 0;
            idFactura = 0;
            articulo = new Articulo();
            Cantidad = 0;
        }
    }
}
