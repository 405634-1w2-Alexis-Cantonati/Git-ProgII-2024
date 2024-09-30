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
        public bool DeleteArticle(int id)
        {
            var lst = new List<Parametros>()
            {
                new Parametros("id",id)
            };
            return HelperDB.GetInstance().EjecutarSql("SP_BORRAR_ARTICULO", lst) > 0;
        }

        public bool CreateArticle(Article oArticulo)
        {
            var lst = new List<Parametros>()
            {
                new Parametros("id",oArticulo.IdArt),
                new Parametros("nombre",oArticulo.Nombre),
                new Parametros("precio",oArticulo.PrecioUnitario),
            };

            return HelperDB.GetInstance().EjecutarSql("SP_CREAR_ARTICULO", lst) > 0;
        }

        public List<Article> GetAllArticle()
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

        public bool UpdateArticle(Article article)
        {
            var lst = new List<Parametros>() 
            {
                new Parametros("@id",article.IdArt),
                new Parametros("@nombre",article.Nombre),
                new Parametros("@precio",article.PrecioUnitario)
            };
            return HelperDB.GetInstance().EjecutarSql("SP_EDITAR_ARTICULO",lst) > 0;
        }

        public bool CreateFactura(Factura oFactura)
        {
            var lst = new List<Parametros>()
            { 
                new Parametros ("@nro_factura",oFactura.IdFactura),
                new Parametros ("@fecha",oFactura.Fecha),
                new Parametros ("@forma_pago",oFactura.FormaPag),
                new Parametros ("@cliente",oFactura.Cliente)
            };
           return HelperDB.GetInstance().EjecutarSql("SP_CREAR_FACTURA",lst) > 0;
        }

        public bool DeleteFactura(int id)
        {
            var lst = new List<Parametros>() { new Parametros("@id",id)};
           return HelperDB.GetInstance().EjecutarSql("SP_BORRAR_FACTURA",lst) > 0;
        }

        public List<Factura> GetFactura(DateTime? fecha, int? formaPago)
        {
            var lstFactura = new List<Factura>();
            var lst = new List<Parametros>()
            {
                new Parametros("@fecha",fecha is not null ? fecha : DBNull.Value),
                new Parametros("@forma_pago",formaPago is not null ? formaPago : DBNull.Value)
            };
            DataTable dt = HelperDB.GetInstance().Consultar("SP_TRAER_FACTURA_PARAM",lst);
            foreach (DataRow dr in dt.Rows)
            {
                Factura f = new Factura();
                f.IdFactura = (int)dr["nro_factura"];
                f.Fecha = (DateTime)dr["fecha"];
                f.FormaPag = (int)dr["forma_pago"];
                f.Cliente = dr["cliente"].ToString();
                lstFactura.Add(f);
            }
            return lstFactura;
        }

        public bool UpdateFactura(Factura oFactura)
        {
            var lst = new List<Parametros>() 
            { 
               new Parametros("@id",oFactura.IdFactura),
               new Parametros("@fecha",oFactura.Fecha),
               new Parametros("@forma_pago",oFactura.FormaPag),
               new Parametros("@cliente",oFactura.Cliente),
            };
            return HelperDB.GetInstance().EjecutarSql("SP_EDITAR_FACTURA",lst) > 0;
        }
    }
}
