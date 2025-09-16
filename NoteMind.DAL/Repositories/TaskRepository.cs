using Microsoft.EntityFrameworkCore;
using NoteMind.DAL.Models;
using NoteMind.DAL.Repositories.Interfaces;

namespace NoteMind.DAL.Repositories
{
    internal class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(NoteMindDbContext context) : base(context) { }

        public async Task<IEnumerable<TaskEntity>> GetByStatusAsync(int status)
        {
            return await _dbSet
                .Where(t => t.Status == status && !t.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetActiveAsync()
        {
            return await _dbSet
                .Where(t => t.Status == 0 && !t.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetCompletedAsync()
        {
            return await _dbSet
                .Where(t => t.Status == 1 && !t.IsDeleted)
                .ToListAsync();
        }
    }
}