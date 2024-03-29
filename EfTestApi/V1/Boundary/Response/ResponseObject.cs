using System;
using System.Collections;
using System.Collections.Generic;

namespace EfTestApi.V1.Boundary.Response
{
    public class CustomerRO
    {
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<RentalRO> Rentals { get; set; }
        public ICollection<PaymentRO> Payments { get; set; }
    }

    public class RentalRO
    {
        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReturnDate { get; set; }
        public int StaffId { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class PaymentRO
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
