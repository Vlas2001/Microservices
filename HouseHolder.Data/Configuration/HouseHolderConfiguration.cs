using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseHolder.Data.Configuration
{
    public class HouseHolderConfiguration: IEntityTypeConfiguration<Entity.HouseHolder>
    {
        public void Configure(EntityTypeBuilder<Entity.HouseHolder> builder)
        {
            builder.HasKey(item => item.Id);
            builder.Property(item => item.Age);
            builder.Property(item => item.Name);
            builder.Property(item => item.Surname);
            builder.Property(item => item.PhoneNumber);
        }
    }
}