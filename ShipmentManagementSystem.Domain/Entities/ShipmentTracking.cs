using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class ShipmentTracking
{
    public int Id { get; set; }

    public int ShipmentId { get; set; }

    public int? WarehouseId { get; set; }

    public string Status { get; set; } = null!;

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? Notes { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual Shipment Shipment { get; set; } = null!;

    public virtual Warehouse? Warehouse { get; set; }
}
