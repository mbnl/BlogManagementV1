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
    public class KategoriRepository : IKategoriRepository
    {
        private readonly BlogContext _context = new BlogContext();
        public int Count()
        {
            return _context.Kategori.Count();
        }

        public void Delete(int id)
        {
            var OurModel = GetByID(id);
            if (OurModel != null)
            {
                _context.Kategori.Remove(OurModel);
            }
        }

        public Kategori Get(Expression<Func<Kategori, bool>> expresssion)
        {
            return _context.Kategori.FirstOrDefault(expresssion);
        }

        public IEnumerable<Kategori> GetAll()
        {
            return _context.Kategori.Select(x => x); // Tüm Kategoriler dönecek
        }

        public Kategori GetByID(int id)
        {
            return _context.Kategori.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Kategori> GetMany(Expression<Func<Kategori, bool>> expresssion)
        {
            return _context.Kategori.Where(expresssion); //Birden fazla döneceği için Where kullandık.
        }

        public void Insert(Kategori obj)
        {
            _context.Kategori.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Kategori obj)
        {
            _context.Kategori.AddOrUpdate(obj);  // AddOrUpdate için System.Data.Entity.Migrations eklenmesi gerekmekte.
        }
    }
}
