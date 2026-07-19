using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Payment
{
    public int Id { get; private set; }

    public int ShipmentId { get; private set; }

    public decimal Amount { get; private set; }

    public string Method { get; private set; } = null!;

    public string Status { get; private set; } = null!;

    public string? TransactionId { get; private set; }

    public DateTime? PaymentDate { get; private set; }

    private Payment()
    {
    }


    private Payment(int shipmentId, decimal amount, string method, string status, string? transactionId, DateTime? paymentDate)
    {
        ShipmentId = shipmentId;
        Amount = amount;
        Method = method;
        Status = status;
        TransactionId = transactionId;
        PaymentDate = paymentDate;
    }

    public static Payment Create(int shipmentId, decimal amount, string method, string status, string? transactionId, DateTime? paymentDate)
    {
        return new Payment(shipmentId, amount, method, status, transactionId, paymentDate);
    }

    public virtual Shipment Shipment { get; private set; } = null!;
}
