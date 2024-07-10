using CreditEntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CreditDataLayer.Context
{
	public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<Guarantor> Guarantors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
