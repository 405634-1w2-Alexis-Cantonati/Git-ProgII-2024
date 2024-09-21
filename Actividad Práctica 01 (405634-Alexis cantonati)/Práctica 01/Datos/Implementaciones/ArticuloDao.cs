using Práctica_01.Datos.Contratos;
using Práctica_01.Datos.Sql;
using Práctica_01.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_01.Datos.Implementaciones
{
    internal class ArticuloDao : IArticulo
    {
        public bool Borrar(int id)
        {
            var lst = new List<Parametros>()
            {
                new Parametros("id",id)
            };
            return HelperDB.GetInstance().EjecutarSql("SP_BORRAR_ARTICULO",lst) > 0;
        }

        public bool CrearArticulo(Articulo oArticulo)
        {
            var lst = new List<Parametros>()
            {
                new Parametros("id",oArticulo.IdArt),
                new Parametros("nombre",oArticulo.Nombre),
                new Parametros("precio",oArticulo.PrecioUnitario),
            };

           return HelperDB.GetInstance().EjecutarSql("SP_CREAR_ARTICULO",lst) > 0;
        }

        public List<Articulo> TraerTodos()
        {
            List<Articulo> lst = new List<Articulo>();
            DataTable dt = HelperDB.GetInstance().Consultar("SP_TRAER_ARTICULOS");
            foreach (DataRow dr in dt.Rows) 
            { 
                Articulo a = new Articulo();
                a.IdArt = (int)dr["id_articulo"];
                a.Nombre = dr["nombre"].ToString();
                a.PrecioUnitario = (int)dr["precio_unitario"];
                lst.Add(a);
            }
            return lst;
        }
    }
}
