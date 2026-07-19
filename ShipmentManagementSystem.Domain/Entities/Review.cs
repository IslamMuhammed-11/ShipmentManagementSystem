using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Review
{
    public int Id { get; init; }

    public int ShipmentId { get; init; }

    public int CustomerId { get; init; }

    public byte Rating { get; private set; }

    public string? Comment { get; private set; }

    public DateTime CreatedAt { get; private set; }


    private Review()
    {
    }

    private Review(int shipmentId, int customerId, byte rating, string? comment, DateTime createdAt)
    {
        ShipmentId = shipmentId;
        CustomerId = customerId;
        Rating = rating;
        Comment = comment;
        CreatedAt = createdAt;
    }

    internal static Review Create(int shipmentId, int customerId, byte rating, string? comment, DateTime createdAt)
    {
        return new Review(shipmentId, customerId, rating, comment, createdAt);
    }

    public void UpdateRating(byte rating)
    {
        Rating = rating;
    }

    public void UpdateComment(string? comment)
    {
        Comment = comment;
    }

    public virtual Customer Customer { get; private set; } = null!;

    public virtual Shipment Shipment { get; private set; } = null!;
}
