using Back.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Data.Repositories
{
    public class TurnosRepository : ITurnosRepository
    {
        db_turnosContext _context;
        public TurnosRepository(db_turnosContext context)
        {
            _context = context;
        }
        public bool Create(TTurno obj)
        {
            if (obj != null)
            {
                _context.TTurnos.Add(obj);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                var turno = _context.TTurnos.Find(id);
                if (turno != null) 
                {
                    _context.TTurnos.Remove(turno);
                    return _context.SaveChanges() > 0;
                }
                return false ;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<TTurno> GetAll()
        {
            return _context.TTurnos.ToList();
        }

        public TTurno? GetById(int id)
        {
           return _context.TTurnos.Find(id);
        }

        public TTurno? Update(TTurno obj)
        {
            if (obj != null)
            {
                _context.TTurnos.Update(obj);
                if(_context.SaveChanges() > 0)
                {
                    return obj;
                }
            }
            return null;
        }
    }
}
