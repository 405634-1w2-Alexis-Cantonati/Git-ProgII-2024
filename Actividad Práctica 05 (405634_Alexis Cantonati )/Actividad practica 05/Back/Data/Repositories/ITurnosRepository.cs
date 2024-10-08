using Back.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Data.Repositories
{
    public interface ITurnosRepository
    {
        public bool Create(TTurno obj);
        public TTurno? Update(TTurno obj);
        public bool Delete(int id);
        public TTurno? GetById(int id);
    }
}
