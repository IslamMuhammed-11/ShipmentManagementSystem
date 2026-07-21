using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
