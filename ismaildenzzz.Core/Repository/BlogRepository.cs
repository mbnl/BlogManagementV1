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
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public int Count()
        {
            return _context.Blog.Count();
        }

        public void Delete(int id)
        {
            var Blog = GetByID(id);
            if (Blog != null)
            {
                _context.Blog.Remove(Blog);
            }
        }

        public Blog Get(Expression<Func<Blog, bool>> expresssion)
        {
            return _context.Blog.FirstOrDefault(expresssion);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _context.Blog.ToList(); // Tüm adminler dönecek
        }

        public Blog GetByID(int id)
        {
            return _context.Blog.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Blog> GetMany(Expression<Func<Blog, bool>> expresssion)
        {
            return _context.Blog.Where(expresssion); //Birden fazla döneceği için Where kullandık.
        }

        public void Insert(Blog obj)
        {
            _context.Blog.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Blog obj)
        {
            _context.Blog.AddOrUpdate(obj);  // AddOrUpdate için System.Data.Entity.Migrations eklenmesi gerekmekte.
        }
    }
}
