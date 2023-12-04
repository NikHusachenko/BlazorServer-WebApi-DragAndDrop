namespace Organization.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(long id);
        
        Task<T?> Find(long id);

        Task<T?> Get(string query, T obj);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(string query, T obj);
    }
}