using Back.Data;
using Back.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Implementacion
{
    public class Aplication : IAplication
    {
        public bool Delete(int id)
        {
            var lst = new List<Parametros>()
            {
                new Parametros("id",id)
            };
            return HelperDB.GetInstance().EjecutarSql("SP_BORRAR_ARTICULO", lst) > 0;
        }

        public bool Create(Article oArticulo)
        {
            var lst = new List<Parametros>()
            {
                new Parametros("id",oArticulo.IdArt),
                new Parametros("nombre",oArticulo.Nombre),
                new Parametros("precio",oArticulo.PrecioUnitario),
            };

            return HelperDB.GetInstance().EjecutarSql("SP_CREAR_ARTICULO", lst) > 0;
        }

        public List<Article> GetAll()
        {
            List<Article> lst = new List<Article>();
            DataTable dt = HelperDB.GetInstance().Consultar("SP_TRAER_ARTICULOS");
            foreach (DataRow dr in dt.Rows)
            {
                Article a = new Article();
                a.IdArt = (int)dr["id_articulo"];
                a.Nombre = dr["nombre"].ToString();
                a.PrecioUnitario = (double)dr["precio_unitario"];
                lst.Add(a);
            }
            return lst;
        }

        public bool Update(Article article)
        {
            var lst = new List<Parametros>() 
            {
                new Parametros("@id",article.IdArt),
                new Parametros("@nombre",article.Nombre),
                new Parametros("@precio",article.PrecioUnitario)
            };
            return HelperDB.GetInstance().EjecutarSql("SP_EDITAR_ARTICULO",lst) > 0;
        }
    }
}
