using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
