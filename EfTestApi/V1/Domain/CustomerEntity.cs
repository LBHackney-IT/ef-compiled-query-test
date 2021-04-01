using System;
using System.Collections.Generic;

namespace EfTestApi.V1.Domain
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<RentalEntity> Rentals { get; set; }
        public ICollection<PaymentEntity> Payments { get; set; }
    }

    public class RentalEntity
    {
        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReturnDate { get; set; }
        public int StaffId { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class PaymentEntity
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
