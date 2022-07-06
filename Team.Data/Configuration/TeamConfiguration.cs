using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Team.Data.Configuration
{
    public class TeamConfiguration: IEntityTypeConfiguration<Entities.Team>
    {
        public void Configure(EntityTypeBuilder<Entities.Team> builder)
        {
            builder.HasKey(item => item.Id);
            builder.Property(item => item.TeamName);
        }
    }
}