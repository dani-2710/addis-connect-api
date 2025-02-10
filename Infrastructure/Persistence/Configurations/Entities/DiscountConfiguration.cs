using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Entities
{
    internal class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable(tb => tb.HasCheckConstraint(
                "CK_Discount_ValidFrom_Future",
                "\"ValidFrom\" > CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"));

            builder.ToTable(tb => tb.HasCheckConstraint(
                "CK_Discount_ValidTo_Future",
                "\"ValidTo\" > CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"));

            builder.ToTable(tb => tb.HasCheckConstraint(
                "CK_Discount_ValidDate",
                "\"ValidFrom\" < \"ValidTo\""));
        }
    }
}
