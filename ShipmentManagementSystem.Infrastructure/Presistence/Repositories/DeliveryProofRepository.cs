using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class DeliveryProofRepository : GenericRepository<DeliveryProof>, IDeliveryProofRepository
{
    public DeliveryProofRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
