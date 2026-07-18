using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Employee
{
    public int UserId { get; set; }

    public string? Department { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual User User { get; set; } = null!;
}
