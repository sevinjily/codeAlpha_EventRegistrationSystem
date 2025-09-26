using EventRegistration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventRegistration.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x=>x.EventName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(500);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.EventName).IsRequired();


            //Relation
            builder.HasMany(e => e.Registrations)
                    .WithOne(e => e.Event)
                    .HasForeignKey(e => e.EventId);






        }
    }
}
