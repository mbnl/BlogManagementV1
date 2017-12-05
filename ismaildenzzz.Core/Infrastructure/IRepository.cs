using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Core.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Tüm dataları getirecek 
        IEnumerable<T> GetAll();
        // Tek bir nesne dönecek
        T GetByID(int id);
        // Expression u dönecek
        T Get(Expression<Func<T, bool>> expresssion);
        // Expression u dönecek
        IQueryable<T> GetMany(Expression<Func<T, bool>> expresssion);

        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        int Count();
        void Save();

    }
}
