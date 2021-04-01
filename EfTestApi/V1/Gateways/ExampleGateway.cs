using System;
using System.Collections.Generic;
using System.Linq;
using EfTestApi.V1.Domain;
using EfTestApi.V1.Factories;
using EfTestApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EfTestApi.V1.Gateways
{
    //TODO: Rename to match the data source that is being accessed in the gateway eg. MosaicGateway
    public class ExampleGateway : IExampleGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ExampleGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public CustomerEntity GetEntityById(int id)
        {
            var result = _databaseContext.CustomerEntities.Find(id);
            return result?.ToDomain();
        }

        public List<CustomerEntity> GetAll()
        {
            // var customers = _databaseContext.CustomerEntities
            //     .Include(ce => ce.Rentals)
            //     .Include(ce => ce.Payments)
            //     .OrderBy(c => c.LastName)
            //     .ThenBy(c => c.FirstName)
            //     .Take(100);

            var customerQuery = EF.CompileQuery((DatabaseContext context) => context.CustomerEntities
                .Include(ce => ce.Rentals)
                .Include(ce => ce.Payments)
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .Take(100));
            var customers = customerQuery(_databaseContext);

            return customers
                .Select(ce => ce.ToDomain()).ToList();
        }
    }
}
