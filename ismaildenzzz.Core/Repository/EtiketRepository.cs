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
    public class EtiketRepository : IEtiketRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public int Count()
        {
            return _context.Etiket.Count();
        }

        public void Delete(int id)
        {
            var OurModel = GetByID(id);
            if (OurModel != null)
            {
                _context.Etiket.Remove(OurModel);
            }
        }

        public Etiket Get(Expression<Func<Etiket, bool>> expresssion)
        {
            return _context.Etiket.FirstOrDefault(expresssion);
        }

        public IEnumerable<Etiket> GetAll()
        {
            return _context.Etiket.Select(x => x); // Tüm Etiketler dönecek
        }

        public Etiket GetByID(int id)
        {
            return _context.Etiket.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Etiket> GetMany(Expression<Func<Etiket, bool>> expresssion)
        {
            return _context.Etiket.Where(expresssion); //Birden fazla döneceği için Where kullandık.
        }

        public void Insert(Etiket obj)
        {
            _context.Etiket.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Etiket obj)
        {
            _context.Etiket.AddOrUpdate(obj);  // AddOrUpdate için System.Data.Entity.Migrations eklenmesi gerekmekte.
        }
    }
}
