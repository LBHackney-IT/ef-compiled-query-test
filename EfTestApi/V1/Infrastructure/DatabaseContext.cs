using Microsoft.EntityFrameworkCore;

namespace EfTestApi.V1.Infrastructure
{

    public class DatabaseContext : DbContext
    {
        //TODO: rename DatabaseContext to reflect the data source it is representing. eg. MosaicContext.
        //Guidance on the context class can be found here https://github.com/LBHackney-IT/lbh-ef-test-api/wiki/DatabaseContext
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerDbEntity> CustomerEntities { get; set; }
        public DbSet<RentalDbEntity> RentalEntities { get; set; }
        public DbSet<RentalDbEntity> PaymentEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDbEntity>(entity =>
            {
                entity.ToTable("customer");
                entity.HasKey(customer => new {customer.CustomerId});
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.StoreId).HasColumnName("store_id");
                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");
                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying");

                entity.HasMany(e => e.Payments);

            });

            modelBuilder.Entity<RentalDbEntity>(entity =>
            {
                entity.ToTable("rental");
                entity.HasKey(rental => new {rental.RentalId});
                entity.Property(e => e.RentalId).HasColumnName("rental_id");
                entity.Property(e => e.RentalDate).HasColumnName("rental_date");
                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Rentals);
            });

            modelBuilder.Entity<PaymentDbEntity>(entity =>
            {
                entity.ToTable("payment");
                entity.HasKey(payment => new {payment.PaymentId});
                entity.Property(e => e.PaymentId).HasColumnName("payment_id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.StaffId).HasColumnName("staff_id");
                entity.Property(e => e.RentalId).HasColumnName("rental_id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Payments);
            });
        }
    }
}
