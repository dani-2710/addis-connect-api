using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Entities
{
    internal class OrganizerConfiguration : IEntityTypeConfiguration<Organizer>
    {
        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder.HasOne(o => o.User)
                .WithOne(u => u.Organizer)
                .HasForeignKey<Organizer>(o => o.UserId);

            builder.ToTable(tb => tb.HasCheckConstraint(
                "CHK_Organizer_Status",
                $"Status IN ('{UserStatus.Active}', '{UserStatus.Inactive}')"));
        }
    }
}
