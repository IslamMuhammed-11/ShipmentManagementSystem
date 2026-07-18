using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public int ShipmentId { get; set; }

    public decimal Amount { get; set; }

    public string Method { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? TransactionId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Shipment Shipment { get; set; } = null!;
}
