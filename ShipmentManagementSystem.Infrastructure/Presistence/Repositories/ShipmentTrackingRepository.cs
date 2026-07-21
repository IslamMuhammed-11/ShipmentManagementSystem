using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class ShipmentTrackingRepository : GenericRepository<ShipmentTracking>, IShipmentTrackingRepository
{
    public ShipmentTrackingRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
