using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
