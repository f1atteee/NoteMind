using Microsoft.EntityFrameworkCore;

namespace NoteMind.DAL
{
    public class NoteMindDbContext : NoteMindDbContext
    {
        public DbSet<Task> Tasks { get; set; }


        public NoteMindDbContext(DbContextOptions<NoteMindDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
