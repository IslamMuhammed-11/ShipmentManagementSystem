using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
