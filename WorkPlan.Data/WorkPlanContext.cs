using Microsoft.EntityFrameworkCore;

namespace WorkPlan.Data
{
    public class WorkPlanContext: DbContext
    {
        public DbSet<Entity.WorkPlan> WorkPlans { get; set; }

        public WorkPlanContext(DbContextOptions<WorkPlanContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}