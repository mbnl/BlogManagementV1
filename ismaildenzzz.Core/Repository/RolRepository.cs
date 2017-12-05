using ismaildenzzz.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ismaildenzzz.Data.Model;
using System.Linq.Expressions;
using ismaildenzzz.Data.DataContext;
using System.Data.Entity.Migrations;

namespace ismaildenzzz.Core.Repository
{
    public class RolRepository : IRolRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public int Count()
        {
            return _context.Rol.Count();
        }

        public void Delete(int id)
        {
            var OurModel = GetByID(id);
            if (OurModel != null)
            {
                _context.Rol.Remove(OurModel);
            }
        }

        public Rol Get(Expression<Func<Rol, bool>> expresssion)
        {
            return _context.Rol.FirstOrDefault(expresssion);
        }

        public IEnumerable<Rol> GetAll()
        {
            return _context.Rol.Select(x => x); // Tüm Roller dönecek
        }

        public Rol GetByID(int id)
        {
            return _context.Rol.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Rol> GetMany(Expression<Func<Rol, bool>> expresssion)
        {
            return _context.Rol.Where(expresssion); //Birden fazla döneceği için Where kullandık.
        }

        public void Insert(Rol obj)
        {
            _context.Rol.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Rol obj)
        {
            _context.Rol.AddOrUpdate(obj);  // AddOrUpdate için System.Data.Entity.Migrations eklenmesi gerekmekte.
        }
    }
}
