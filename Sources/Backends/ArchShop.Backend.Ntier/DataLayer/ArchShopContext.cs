
using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ArchShop.DataLayer
{
    public class ArchShopContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Address> Addresses => Set<Address>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Account mapping
            var accountBuilder = modelBuilder.Entity<Account>();
            accountBuilder
                .Property(a => a.Id)
                .HasConversion(
                    f => f.Value,
                    f => new AccountId(f));
            accountBuilder
                .Property(a => a.FirstName)
                .HasMaxLength(128);
            accountBuilder
                .Property(a => a.LastName)
                .HasMaxLength(128);

            // Address mapping
            var addressBuilder = modelBuilder.Entity<Address>();
            addressBuilder
                .Property(a => a.Id)
                .HasConversion(
                    f => f.Value,
                    f => new AddressId(f));
            addressBuilder
                .Property(a => a.Street)
                .HasMaxLength(256);
            addressBuilder
                .Property(a => a.City)
                .HasMaxLength(128);
        }
    }
}
