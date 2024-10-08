using Back.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Data.Repositories
{
    public interface IServicioRepository
    {
        public bool Create(TServicio obj);
        public bool Update(TServicio obj);
        public bool Delete(int id);
        public TServicio? GetById(int id);
        public List<TServicio> GetAll();
    }
}
