using CreditEntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditDataLayer.Configurations
{
	public class LoanDetailConfiguration : IEntityTypeConfiguration<LoanDetail>
    {
        public void Configure(EntityTypeBuilder<LoanDetail> builder)
        {
            builder.Property(l => l.Principal)
                 .HasPrecision(18, 2);
        }
    }
}
