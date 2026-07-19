using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Notification
{
    public int Id { get; private set; }

    public int UserId { get; private set; }

    public string Type { get; private set; } = null!;

    public string Message { get; private set; } = null!;

    public bool IsRead { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private Notification()
    {
    }

    private Notification(int userId , string type, string message , bool isRead , DateTime createdAt)
    {
        UserId = userId;
        Type = type;
        Message = message;
        IsRead = isRead;
        CreatedAt = createdAt;
    }

    public static Notification Create(int userId , string type, string message , bool isRead , DateTime createdAt)
    {
        return new Notification(userId, type, message, isRead, createdAt);
    }

    public virtual User User { get; private set; } = null!;
}
