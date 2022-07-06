using HouseHolder.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseHolder.Data.Configuration
{
    public class HouseRequestConfiguration: IEntityTypeConfiguration<HouseRequest>
    {
        public void Configure(EntityTypeBuilder<HouseRequest> builder)
        {
            builder.HasKey(item => item.Id);
            builder.Property(item => item.IsFormed);
            builder.Property(item => item.WorkScale);
            builder.Property(item => item.WorkTime);
            builder.Property(item => item.WorkType);
        }
    }
}