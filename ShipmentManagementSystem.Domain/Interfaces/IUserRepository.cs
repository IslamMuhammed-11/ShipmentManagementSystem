using ShipmentManagementSystem.Domain.Entities;

namespace ShipmentManagementSystem.Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> DoesUserExistByEmail(string email , CancellationToken ct);
}
