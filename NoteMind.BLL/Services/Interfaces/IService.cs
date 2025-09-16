namespace NoteMind.BLL.Services.Interfaces
{
    public interface IService<T>
    {
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAll(int skip, int take);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(long id);
        Task<T> GetLastItemAsync();
    }
}