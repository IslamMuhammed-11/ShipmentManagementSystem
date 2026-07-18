using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class DeliveryProof
{
    public int Id { get; set; }

    public int ShipmentId { get; set; }

    public string ReceiverName { get; set; } = null!;

    public string? SignatureUrl { get; set; }

    public string? ProofImageUrl { get; set; }

    public string? DeliveryNotes { get; set; }

    public DateTime DeliveredAt { get; set; }

    public virtual Shipment Shipment { get; set; } = null!;
}
