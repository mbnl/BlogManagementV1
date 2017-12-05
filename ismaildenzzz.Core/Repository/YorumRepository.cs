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
    public class YorumRepository : IYorumRepository
    {
        private readonly BlogContext _context = new BlogContext();
        public int Count()
        {
            return _context.Yorum.Count();
        }

        public void Delete(int id)
        {
            var OurModel = GetByID(id);
            if (OurModel != null)
            {
                _context.Yorum.Remove(OurModel);
            }
        }

        public Yorum Get(Expression<Func<Yorum, bool>> expresssion)
        {
            return _context.Yorum.FirstOrDefault(expresssion);
        }

        public IEnumerable<Yorum> GetAll()
        {
            return _context.Yorum.Include("Blog").Select(x => x); // Tüm Yorumler dönecek
        }

        public Yorum GetByID(int id)
        {
            return _context.Yorum.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Yorum> GetMany(Expression<Func<Yorum, bool>> expresssion)
        {
            return _context.Yorum.Where(expresssion); //Birden fazla döneceği için Where kullandık.
        }

        public void Insert(Yorum obj)
        {
            _context.Yorum.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Yorum obj)
        {
            _context.Yorum.AddOrUpdate(obj);  // AddOrUpdate için System.Data.Entity.Migrations eklenmesi gerekmekte.
        }
        
    }
}
