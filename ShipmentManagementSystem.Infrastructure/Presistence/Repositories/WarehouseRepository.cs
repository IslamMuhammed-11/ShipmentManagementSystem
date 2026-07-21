using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
{
    public WarehouseRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
