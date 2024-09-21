using Práctica_01.Datos.Sql;
using Práctica_01.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Práctica_01.Datos.Contratos;

namespace Práctica_01.Datos.Implementaciones
{
    internal class FacturaDao : IFactura
    {
        public bool Borrar(int id)
        {
            var lista = new List<Parametros>()
            {
                new Parametros("@id",id)
            };
            int filasAfectadas = HelperDB.GetInstance().EjecutarSql("SP_BORRAR_FACTURA",lista);
            return filasAfectadas > 0;
        }

        public bool CrearFactura(Factura factura)
        {

            var lista = new List<Parametros>() {
             new Parametros("@nro_factura",factura.IdFactura),
             new Parametros("@fecha",factura.Fecha),
             new Parametros("@forma_pago",factura.FormaPag),
             new Parametros("@cliente",factura.Cliente)
            };

            foreach (DetalleFactura d in factura.TraerDetalles())
            {
                var listaDetalle = new List<Parametros>()
                {
                  new Parametros("id",d.IdDetalle),
                  new Parametros("factura",d.idFactura),
                  new Parametros("articulo",d.articulo),
                  new Parametros("cantidad",d.Cantidad)
                };
                HelperDB.GetInstance().EjecutarSql("SP_CREAR_DETALLE",listaDetalle);
            }

            return HelperDB.GetInstance().EjecutarSql("SP_CREAR_FACTURA", lista) > 0;
        }

        public List<Factura> TraerTodos()
        {
            List<Factura> lst = new List<Factura>();
            Factura? f = null;
            DataTable dt = HelperDB.GetInstance().Consultar("SP_TRAER_FACTURAS");
            foreach (DataRow row in dt.Rows) 
            {
                if (f == null || f.IdFactura != Convert.ToInt32(row["nro_factura"].ToString()))
                {
                    f = new Factura();
                    f.IdFactura = (int)row["nro_factura"];
                    f.Fecha = (DateTime)row["fecha"];
                    f.FormaPag = (int)row["forma_pago"];
                    f.Cliente = row["cliente"].ToString();
                    f.AgregarDetalle(leerDetalle(row));
                    lst.Add(f);
                }
                else 
                {
                    f.AgregarDetalle(leerDetalle(row));
                }
                
            }
            return lst;
        }
        private DetalleFactura leerDetalle(DataRow row)
        {
            DetalleFactura d = new DetalleFactura();
            d.articulo = new Articulo()
            {
                IdArt = (int)row["id_articulo"],
                Nombre = row["nombre"].ToString(),
                PrecioUnitario = (int)row["precio_unitario"]

            };
            d.IdDetalle = (int)row["id_detalle"];
            d.Cantidad = (int)row["cantidad"];
            return d;
        }
    }
}
