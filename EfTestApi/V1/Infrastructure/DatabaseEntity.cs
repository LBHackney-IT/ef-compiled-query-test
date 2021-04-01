using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfTestApi.V1.Infrastructure
{
    [Table("customer")]
    public class CustomerDbEntity
    {
        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("address_id")]
        public int AddressId { get; set; }
        [Column("create_date")]
        public DateTime CreateDate { get; set; }
        [Column("last_update")]
        public DateTime LastUpdated { get; set; }
        public ICollection<RentalDbEntity> Rentals { get; set; }
        public ICollection<PaymentDbEntity> Payments { get; set; }
    }

    [Table("rental")]
    public class RentalDbEntity
    {
        [Key]
        [Column("rental_id")]
        public int RentalId { get; set; }
        [Column("rental_date")]
        public DateTime RentalDate { get; set; }
        [Column("inventory_id")]
        public int InventoryId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("return_date")]
        public DateTime ReturnDate { get; set; }
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Column("last_update")]
        public DateTime LastUpdated { get; set; }

        public CustomerDbEntity Customer { get; set; }
    }

    [Table("payment")]
    public class PaymentDbEntity
    {
        [Key]
        [Column("payment_id")]
        public int PaymentId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Column("rental_id")]
        public int RentalId { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }

        public CustomerDbEntity Customer { get; set; }
        public RentalDbEntity Rental { get; set; }
    }
}
