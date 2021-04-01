using System.Collections.Generic;
using System.Linq;
using EfTestApi.V1.Boundary.Response;
using EfTestApi.V1.Domain;

namespace EfTestApi.V1.Factories
{
    public static class ResponseFactory
    {
        //TODO: Map the fields in the domain object(s) to fields in the response object(s).
        // More information on this can be found here https://github.com/LBHackney-IT/lbh-ef-test-api/wiki/Factory-object-mappings
        public static CustomerRO ToResponse(this CustomerEntity domain)
        {
            return new CustomerRO
            {
                CustomerId = domain.CustomerId,
                StoreId = domain.StoreId,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                Email = domain.Email,
                AddressId = domain.AddressId,
                CreateDate = domain.CreateDate,
                LastUpdated = domain.LastUpdated,
                Rentals = domain.Rentals.ToResponse(),
                Payments = domain.Payments.ToResponse()
            };
        }

        public static List<CustomerRO> ToResponse(this IEnumerable<CustomerEntity> domainList)
        {
            return domainList?.Select(domain => domain.ToResponse()).ToList();
        }

        public static RentalRO ToResponse(this RentalEntity domain)
        {
            return new RentalRO
            {
                RentalId = domain.RentalId,
                RentalDate = domain.RentalDate,
                InventoryId = domain.InventoryId,
                CustomerId = domain.CustomerId,
                ReturnDate = domain.ReturnDate,
                StaffId = domain.StaffId,
                LastUpdated = domain.LastUpdated
            };
        }

        public static List<RentalRO> ToResponse(this IEnumerable<RentalEntity> domainList)
        {
            return domainList?.Select(domain => domain.ToResponse()).ToList();
        }

        public static PaymentRO ToResponse(this PaymentEntity domain)
        {
            return new PaymentRO
            {
                PaymentId = domain.PaymentId,
                CustomerId = domain.CustomerId,
                StaffId = domain.StaffId,
                RentalId = domain.RentalId,
                Amount = domain.Amount,
                PaymentDate = domain.PaymentDate
            };
        }

        public static List<PaymentRO> ToResponse(this IEnumerable<PaymentEntity> domainList)
        {
            return domainList?.Select(domain => domain.ToResponse()).ToList();
        }
    }
}
