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
    public class IletisimRepository : ILetisimRepository
    {
        private readonly BlogContext _context = new BlogContext();
        public int Count()
        {
            return _context.Iletisim.Count();
        }

        public void Delete(int id)
        {
            var OurModel = GetByID(id);
            if (OurModel != null)
            {
                _context.Iletisim.Remove(OurModel);
            }
        }

        public Iletisim Get(Expression<Func<Iletisim, bool>> expresssion)
        {
            return _context.Iletisim.FirstOrDefault(expresssion);
        }

        public IEnumerable<Iletisim> GetAll()
        {
            return _context.Iletisim.Select(x => x); // Tüm Iletisimler dönecek
        }

        public Iletisim GetByID(int id)
        {
            return _context.Iletisim.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Iletisim> GetMany(Expression<Func<Iletisim, bool>> expresssion)
        {
            return _context.Iletisim.Where(expresssion); //Birden fazla döneceği için Where kullandık.
        }

        public void Insert(Iletisim obj)
        {
            _context.Iletisim.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Iletisim obj)
        {
            _context.Iletisim.AddOrUpdate(obj);  // AddOrUpdate için System.Data.Entity.Migrations eklenmesi gerekmekte.
        }
    }
}
