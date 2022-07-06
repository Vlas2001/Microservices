using Microsoft.EntityFrameworkCore;
using Team.Data.Configuration;
using Team.Entity;

namespace Team.Data
{
    public class TeamContext: DbContext
    {
        public DbSet<Entities.Team> Teams { get; set; }
        
        public DbSet<Worker> Workers { get; set; }

        public TeamContext(DbContextOptions<TeamContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
        }
    }
}