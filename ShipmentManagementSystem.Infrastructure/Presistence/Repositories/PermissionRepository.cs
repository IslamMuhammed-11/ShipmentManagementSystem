using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
{
    public PermissionRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
