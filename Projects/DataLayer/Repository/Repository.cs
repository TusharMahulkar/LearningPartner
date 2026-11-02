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
        
        public bool AddItem(T item)
        {
            try
            {
                _dbset.Add(item);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;                
            }            
        }

        public bool BulkAddItems(List<T> items)
        {
            try
            {
                _dbset.AddRange(items);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }            
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
