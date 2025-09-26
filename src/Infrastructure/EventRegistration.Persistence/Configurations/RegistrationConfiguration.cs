using EventRegistration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Persistence.Configurations
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.Property(x => x.RegisteredDate).IsRequired();

            //Relations
            builder.HasOne(e => e.User)
                .WithMany(e => e.Registrations)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(e => e.EventId);

        }
    }
}
