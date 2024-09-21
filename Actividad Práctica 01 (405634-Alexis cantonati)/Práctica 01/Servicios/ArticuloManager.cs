using Práctica_01.Datos.Contratos;
using Práctica_01.Datos.Implementaciones;
using Práctica_01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_01.Servicios
{
    public class ArticuloManager
    {
        private IArticulo _articulo;
        public ArticuloManager()
        {
            _articulo = new ArticuloDao();
        }

        public bool Borrar(int id)
        {
            return _articulo.Borrar(id);
        }

        public bool CrearArticulo(Articulo oArticulo)
        {
            return _articulo.CrearArticulo(oArticulo);
        }

        public List<Articulo> TraerTodos()
        {
            return _articulo.TraerTodos();
        }
    }
}
