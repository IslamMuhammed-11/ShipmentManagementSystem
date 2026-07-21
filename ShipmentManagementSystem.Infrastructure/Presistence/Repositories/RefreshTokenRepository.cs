using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
