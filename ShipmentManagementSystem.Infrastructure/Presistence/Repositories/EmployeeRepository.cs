using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Infrastructure.Presistence.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(LogisticsShipmentDbContext context) : base(context)
    {
    }
}
