using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Entities
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.FirstName).HasMaxLength(255);
            builder.Property(user => user.LastName).HasMaxLength(255);
            builder.Property(user => user.Email).HasMaxLength(255);
            builder.Property(user => user.PhoneNumber).HasMaxLength(20);
        }
    }
}
