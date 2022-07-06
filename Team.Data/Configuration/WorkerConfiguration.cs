using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Team.Entity;

namespace Team.Data.Configuration
{
    public class WorkerConfiguration: IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.Age);
            builder.Property(item => item.Name);
            builder.Property(item => item.Surname);
            builder.Property(item => item.PhoneNumber);
            builder.HasOne(item => item.Team)
                .WithMany(item => item.Workers);
        }
    }
}