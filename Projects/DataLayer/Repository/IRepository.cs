namespace SQLDataLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        bool AddItem(T item);
        public List<T> GetAll();

        public T GetById(int id);
    }
}
