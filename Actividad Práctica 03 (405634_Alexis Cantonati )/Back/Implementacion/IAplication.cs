using Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Implementacion
{
    public interface IAplication
    {
        bool CreateArticle(Article oArticulo);
        bool DeleteArticle(int id);
        List<Article> GetAllArticle();
        bool UpdateArticle(Article article);


        bool CreateFactura(Factura oFactura);
        bool DeleteFactura(int id);
        List<Factura> GetFactura(DateTime? fecha, int? formaPago);
        bool UpdateFactura(Factura oFactura);
    }
}
