using NoteMind.DAL.Repositories.Interfaces;
using NoteMind.DAL.Repositories;
using NoteMind.DAL.Interface;
using NoteMind.DAL.Models;

namespace NoteMind.DAL
{
    internal class UnitOfWork : IUnitOfWork
    {
        protected readonly NoteMindDbContext _context;

        public ITaskRepository TaskRepository { get; set; }

        private bool _disposed = false;

        public UnitOfWork(NoteMindDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            _context = context;
            TaskRepository = new TaskRepository(context);
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Model
        {
            return new GenericRepository<TEntity>(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this._disposed = true;
        }
    }
}