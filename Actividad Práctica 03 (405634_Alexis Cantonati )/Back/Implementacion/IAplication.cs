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
        bool Create(Article oArticulo);
        bool Delete(int id);
        List<Article> GetAll();
        bool Update(Article article);
    }
}
