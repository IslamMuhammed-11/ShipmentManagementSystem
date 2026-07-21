using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class DriverLocationPingRepository : GenericRepository<DriverLocationPing>, IDriverLocationPingRepository
{
    public DriverLocationPingRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
