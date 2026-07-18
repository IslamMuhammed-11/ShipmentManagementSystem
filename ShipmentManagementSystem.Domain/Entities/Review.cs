using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Review
{
    public int Id { get; set; }

    public int ShipmentId { get; set; }

    public int CustomerId { get; set; }

    public byte Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Shipment Shipment { get; set; } = null!;
}
