using HouseHolder.Data.Configuration;
using HouseHolder.Entity;
using Microsoft.EntityFrameworkCore;

namespace HouseHolder.Data
{
    public class HouseHolderContext: DbContext
    {
        public DbSet<Entity.HouseHolder> HouseHolders { get; set; }
        public DbSet<HouseRequest> HouseRequests { get; set; }

        public HouseHolderContext(DbContextOptions<HouseHolderContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new HouseHolderConfiguration());
            modelBuilder.ApplyConfiguration(new HouseRequestConfiguration());
        }
    }
}