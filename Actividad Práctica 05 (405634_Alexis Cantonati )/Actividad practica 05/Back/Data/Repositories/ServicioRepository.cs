using Back.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Data.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        db_turnosContext _context;
        public ServicioRepository(db_turnosContext context)
        {
            _context = context;
        }
        public bool Create(TServicio obj)
        {
            if (obj != null && GetById(obj.Id) == null)
            {
                _context.TServicios.Add(obj);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                _context.TServicios.Remove(obj);
                return _context.SaveChanges() > 0;
            }
            return false ;
        }

        public List<TServicio> GetAll()
        {
            return _context.TServicios.ToList();
        }

        public TServicio? GetById(int id)
        {
            return _context.TServicios.Find(id);
        }

        public bool Update(TServicio obj)
        {
            if(obj != null)
            {
                _context.TServicios.Update(obj);
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
