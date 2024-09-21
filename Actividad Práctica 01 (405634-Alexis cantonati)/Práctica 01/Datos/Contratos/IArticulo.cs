using Práctica_01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_01.Datos.Contratos
{
    internal interface IArticulo
    {
        bool CrearArticulo(Articulo oArticulo);
        bool Borrar(int id);
        List<Articulo> TraerTodos();
    }
}
