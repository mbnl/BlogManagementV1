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
    public class AdminRepository : IAdminRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public int Count()
        {
            return _context.Admin.Count();
        }

        public void Delete(int id)
        {
            var Admin = GetByID(id);
            if(Admin != null)
            {
                _context.Admin.Remove(Admin);
            }
        }

        public Admin Get(Expression<Func<Admin, bool>> expresssion)
        {
            return _context.Admin.Include("Rol").FirstOrDefault(expresssion);
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Admin.Include("Rol").Select(x => x); // Tüm adminler dönecek
        }

        public Admin GetByID(int id)
        {
            return _context.Admin.Include("Rol").FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Admin> GetMany(Expression<Func<Admin, bool>> expresssion)
        {
            return _context.Admin.Include("Rol").Where(expresssion); //Birden fazla döneceği için Where kullandık.
        }

        public void Insert(Admin obj)
        {
            _context.Admin.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Admin obj)
        {
            _context.Admin.AddOrUpdate(obj);  // AddOrUpdate için System.Data.Entity.Migrations eklenmesi gerekmekte.
        }
    }
}
