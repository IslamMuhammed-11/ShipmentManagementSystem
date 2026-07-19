using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class DeliveryProof
{
    public int Id { get; init; }

    public int ShipmentId { get; init; }

    public string ReceiverName { get; init; } = null!;

    public string? SignatureUrl { get; private set; }

    public string? ProofImageUrl { get; private set; }

    public string? DeliveryNotes { get; private set; }

    public DateTime DeliveredAt { get; private set; }


    private DeliveryProof()
    {
    }
    private DeliveryProof(int shipmentId, string receiverName, string? signatureUrl, string? proofImageUrl, string? deliveryNotes, DateTime deliveredAt)
    {
        ShipmentId = shipmentId;
        ReceiverName = receiverName;
        SignatureUrl = signatureUrl;
        ProofImageUrl = proofImageUrl;
        DeliveryNotes = deliveryNotes;
        DeliveredAt = deliveredAt;
    }

    public static DeliveryProof Create(int shipmentId, string receiverName, string? signatureUrl, string? proofImageUrl, string? deliveryNotes, DateTime deliveredAt)
    {

        return new DeliveryProof(shipmentId, receiverName, signatureUrl, proofImageUrl, deliveryNotes, deliveredAt);
    }

    public virtual Shipment Shipment { get; private set; } = null!;
}
