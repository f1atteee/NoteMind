using Microsoft.EntityFrameworkCore;
using NoteMind.DAL.Models;

namespace NoteMind.DAL
{
    public class NoteMindDbContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }


        public NoteMindDbContext(DbContextOptions<NoteMindDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}