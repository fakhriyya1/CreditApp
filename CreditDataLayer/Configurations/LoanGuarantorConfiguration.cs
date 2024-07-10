using CreditEntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditDataLayer.Configurations
{
	public class LoanGuarantorConfiguration : IEntityTypeConfiguration<LoanGuarantor>
    {
        public void Configure(EntityTypeBuilder<LoanGuarantor> builder)
        {
            builder.HasKey(cg => new { cg.GuarantorId, cg.LoanDetailId });

            builder.HasOne(cg => cg.LoanDetail)
                   .WithMany(c => c.Guarantors)
                   .HasForeignKey(cg => cg.LoanDetailId);

            builder.HasOne(cg => cg.Guarantor)
                   .WithMany(g => g.Loans)
                   .HasForeignKey(cg => cg.GuarantorId);
        }
    }
}
