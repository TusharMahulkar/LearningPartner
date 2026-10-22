namespace SQLDataLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        void AddItem(T item);
        public List<T> GetAll();

        public T GetById(int id);
    }
}
