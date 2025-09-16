using NoteMind.DAL.Models;
using NoteMind.DAL.Repositories.Interfaces;

namespace NoteMind.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository TaskRepository { get; }

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Model;

        Task SaveAsync();
    }
}
