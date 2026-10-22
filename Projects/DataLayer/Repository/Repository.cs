using DataLayer.DataModel;
using Microsoft.EntityFrameworkCore;

namespace SQLDataLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private eShopWebDB _dbContext;
        private DbSet<T> _dbset;

        public Repository(eShopWebDB dbObjectBydependncy)
        {
            _dbContext = dbObjectBydependncy;
            _dbset = dbObjectBydependncy.Set<T>();
        }
        
        public void AddItem(T item)
        {
            _dbset.Add(item);
            _dbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T? GetById(int id)
        {
            return _dbset.Find(id);
        }

    }
}
