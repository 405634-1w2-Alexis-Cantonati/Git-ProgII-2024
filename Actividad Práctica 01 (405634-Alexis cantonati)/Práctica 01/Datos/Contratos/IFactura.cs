using Práctica_01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_01.Datos
{
    internal interface IFactura
    {
        bool CrearFactura(Factura factura);
        bool Borrar(int id);
        List<Factura> TraerTodos();
    }
}
