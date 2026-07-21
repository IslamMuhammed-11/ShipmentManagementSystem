using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class VehicleTypeRepository : GenericRepository<VehicleType>, IVehicleTypeRepository
{
    public VehicleTypeRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
