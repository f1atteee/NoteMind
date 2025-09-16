using NoteMind.DAL.Models;

namespace NoteMind.DAL.Repositories.Interfaces
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetByStatusAsync(int status);
        Task<IEnumerable<TaskEntity>> GetActiveAsync();
        Task<IEnumerable<TaskEntity>> GetCompletedAsync();
    }
}