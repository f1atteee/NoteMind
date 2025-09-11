namespace NoteMind.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetByLimitAsync(int skip, int limit);
        Task<T> Create(T entity);
        Task Update(T item);
        Task Delete(long id);
        Task<int> Count();
        Task<T?> GetLastItemAsync();
    }
}