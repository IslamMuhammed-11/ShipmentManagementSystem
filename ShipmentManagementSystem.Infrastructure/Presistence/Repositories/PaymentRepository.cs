using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
