using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShipmentManagementSystem.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipmentManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<LogisticsShipmentDbContext>(options => options.UseSqlServer());

        // Add other infrastructure services here, such as repositories, unit of work, etc.
        return services;
    }
}
