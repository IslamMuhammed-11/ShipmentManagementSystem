using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
