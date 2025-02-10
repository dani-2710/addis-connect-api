using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Entities
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(255);

            builder.ToTable(tb => tb.HasCheckConstraint(
                "CHK_Category_Status",
                $"Status IN ('{CategoryStatus.Active}', '{CategoryStatus.Inactive}')"));
        }
    }
}
