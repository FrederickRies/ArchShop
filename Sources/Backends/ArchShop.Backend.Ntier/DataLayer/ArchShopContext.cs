
using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ArchShop.DataLayer
{
    public class ArchShopContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
        public DbSet<Delivery> Deliveries => Set<Delivery>();

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

            // Product mapping
            var productBuilder = modelBuilder.Entity<Product>();
            productBuilder
                .Property(p => p.Id)
                .HasConversion(
                    f => f.Value,
                    f => new ProductId(f));
            productBuilder
                .Property(p => p.Label)
                .HasMaxLength(128);
            productBuilder
                .Property(p => p.Description)
                .HasMaxLength(2058);

            // Order mapping
            var orderBuilder = modelBuilder.Entity<Order>();
            orderBuilder
                .Property(o => o.Id)
                .HasConversion(
                    f => f.Value,
                    f => new OrderId(f));
            orderBuilder
                .Property(o => o.AccountId)
                .HasConversion(
                    f => f.Value,
                    f => new AccountId(f));

            // Order products mapping
            var orderProductsBuilder = modelBuilder.Entity<OrderProduct>();
            orderProductsBuilder
                .Property(op => op.OrderId)
                .HasConversion(
                    f => f.Value,
                    f => new OrderId(f));
            orderProductsBuilder
                .Property(op => op.ProductId)
                .HasConversion(
                    f => f.Value,
                    f => new ProductId(f));

            // Delivery products mapping
            var deliveryBuilder = modelBuilder.Entity<Delivery>();
            deliveryBuilder
                .Property(d => d.Id)
                .HasConversion(
                    f => f.Value,
                    f => new DeliveryId(f));
            deliveryBuilder
                .Property(d => d.OrderId)
                .HasConversion(
                    f => f.Value,
                    f => new OrderId(f));
            deliveryBuilder
                .Property(d => d.AddressId)
                .HasConversion(
                    f => f.Value,
                    f => new AddressId(f));


        }
    }
}
