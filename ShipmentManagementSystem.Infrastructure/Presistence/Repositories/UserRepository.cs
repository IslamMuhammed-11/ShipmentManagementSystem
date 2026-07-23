using Microsoft.EntityFrameworkCore;
using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }

    public async Task<bool> DoesUserExistByEmail(string email , CancellationToken ct)
    {
        return await _dbSet.AnyAsync(e => e.Email == email , ct);
    }
}
