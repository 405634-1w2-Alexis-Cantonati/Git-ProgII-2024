using Práctica_01.Datos;
using Práctica_01.Datos.Implementaciones;
using Práctica_01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_01.Servicios
{
    public class FacturaManager
    {
        private IFactura _factura;

        public FacturaManager()
        { 
            _factura = new FacturaDao();
        }
        public bool Borrar(int id)
        {
            return _factura.Borrar(id);
        }

        public bool CrearFactura(Factura factura)
        {
            return _factura.CrearFactura(factura);
        }

        public List<Factura> TraerTodos()
        {
            return _factura.TraerTodos();
        }
    }
}
