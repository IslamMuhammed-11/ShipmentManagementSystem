using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
