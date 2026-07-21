using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
