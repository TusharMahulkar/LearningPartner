namespace SQLDataLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        bool AddItem(T item);

        bool BulkAddItems(List<T> items);

        public List<T> GetAll();

        public T GetById(int id);
    }
}
