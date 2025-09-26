using EventRegistration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventRegistration.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.BirthDate)
                    .IsRequired(); 

            // Relation
            builder.HasMany(u => u.Registrations)
                   .WithOne(r => r.User)
                   .HasForeignKey(r => r.UserId);
        }
    }
}
