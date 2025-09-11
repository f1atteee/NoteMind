using Microsoft.EntityFrameworkCore;
using NoteMind.DAL.Models;

namespace NoteMind.DAL.Repositories
{
    internal class BaseRepository<T> where T : Model
    {
        protected readonly NoteMindDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(NoteMindDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            _context = context;
            _dbSet = context.Set<T>();
        }
    }
}
