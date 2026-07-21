using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    public AddressRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }

    
}
