using CreditEntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditDataLayer.Configurations
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(c => c.LoanDetails)
                .WithOne(l => l.Customer)
                .HasForeignKey(l => l.CustomerId)
                .IsRequired();
        }
    }
}
