using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class CustomerAddressRepository : GenericRepository<CustomerAddress> , ICustomerAddressRepository
{
    public CustomerAddressRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
