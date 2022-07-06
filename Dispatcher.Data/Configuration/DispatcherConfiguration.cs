using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dispatcher.Data.Configuration
{
    public class DispatcherConfiguration: IEntityTypeConfiguration<Dispatcher.Entity.Dispatcher>
    {
        public void Configure(EntityTypeBuilder<Dispatcher.Entity.Dispatcher> builder)
        {
            builder.HasKey(dispatcher => dispatcher.Id);
            builder.Property(dispatcher => dispatcher.Age);
            builder.Property(dispatcher => dispatcher.Name);
            builder.Property(dispatcher => dispatcher.Surname);
            builder.Property(dispatcher => dispatcher.PhoneNumber);
        }
    }
}