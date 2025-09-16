using Microsoft.EntityFrameworkCore;
using NoteMind.DAL.Models;
using NoteMind.DAL.Repositories.Interfaces;

namespace NoteMind.DAL.Repositories
{
    internal class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T> where T : Model
    {
        public GenericRepository(NoteMindDbContext context) : base(context) { }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetByLimitAsync(int skip, int limit)
        {
            return await _dbSet.OrderBy(x => x.Id).Skip(skip).Take(limit).ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return entity;
        }

        public async Task<T> Create(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var eventModel = await _dbSet.FindAsync(entity.Id);
            if (eventModel == null)
            {
                throw new ArgumentNullException(nameof(eventModel));
            }
            _context.Entry(eventModel).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(long id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var eventModel = await _dbSet.FindAsync(id);
            if (eventModel == null)
            {
                throw new ArgumentNullException(nameof(eventModel));
            }
            _dbSet.Remove(eventModel);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<T?> GetLastItemAsync()
        {
            return await _dbSet.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
