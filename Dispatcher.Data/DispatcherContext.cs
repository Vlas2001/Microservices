using Dispatcher.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Dispatcher.Data
{
    public class DispatcherContext: DbContext
    {
        public DbSet<Entity.Dispatcher> Dispatchers { get; set; }

        public DispatcherContext(DbContextOptions<DispatcherContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new DispatcherConfiguration());
        }
    }
}