using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
{
    public ShipmentRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
