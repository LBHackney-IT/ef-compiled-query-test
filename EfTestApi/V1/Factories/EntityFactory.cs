using System.Collections.Generic;
using System.Linq;
using EfTestApi.V1.Domain;
using EfTestApi.V1.Infrastructure;

namespace EfTestApi.V1.Factories
{
    public static class EntityFactory
    {
        public static CustomerEntity ToDomain(this CustomerDbEntity customerEntity)
        {
            return new CustomerEntity()
            {
                CustomerId = customerEntity.CustomerId,
                CreateDate = customerEntity.CreateDate,
                StoreId = customerEntity.StoreId,
                FirstName = customerEntity.FirstName,
                LastName = customerEntity.LastName,
                Email = customerEntity.Email,
                AddressId = customerEntity.AddressId,
                LastUpdated = customerEntity.LastUpdated,
                Rentals = customerEntity.Rentals.ToDomain(),
                Payments = customerEntity.Payments.ToDomain()
            };
        }

        public static RentalEntity ToDomain(this RentalDbEntity rentalEntity)
        {
            return new RentalEntity()
            {
                RentalId = rentalEntity.RentalId,
                RentalDate = rentalEntity.RentalDate,
                InventoryId = rentalEntity.InventoryId,
                CustomerId = rentalEntity.CustomerId,
                ReturnDate = rentalEntity.ReturnDate,
                StaffId = rentalEntity.StaffId,
                LastUpdated = rentalEntity.LastUpdated
            };
        }

        private static List<RentalEntity> ToDomain(this ICollection<RentalDbEntity> rentalEntities)
        {
            return rentalEntities?.Select(re => re.ToDomain()).ToList();
        }

        public static PaymentEntity ToDomain(this PaymentDbEntity paymentEntity)
        {
            return new PaymentEntity()
            {
                PaymentId = paymentEntity.PaymentId,
                CustomerId = paymentEntity.CustomerId,
                StaffId = paymentEntity.StaffId,
                RentalId = paymentEntity.RentalId,
                Amount = paymentEntity.Amount,
                PaymentDate = paymentEntity.PaymentDate
            };
        }

        private static List<PaymentEntity> ToDomain(this ICollection<PaymentDbEntity> paymentEntities)
        {
            return paymentEntities?.Select(re => re.ToDomain()).ToList();
        }

    }
}
