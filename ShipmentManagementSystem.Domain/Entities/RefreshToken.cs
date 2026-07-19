using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class RefreshToken
{
    public int Id { get; private set; }

    public int UserId { get; private set; }

    public string TokenHash { get; private set; } = null!;

    public DateTime ExpiresAt { get; private set; }

    public bool IsRevoked { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private RefreshToken()
    {
    }

    private RefreshToken(int userId, string tokenHash, DateTime expiresAt, bool isRevoked, DateTime createdAt)
    {
        UserId = userId;
        TokenHash = tokenHash;
        ExpiresAt = expiresAt;
        IsRevoked = isRevoked;
        CreatedAt = createdAt;
    }

    internal static RefreshToken Create(int userId, string tokenHash, DateTime expiresAt, bool isRevoked, DateTime createdAt)
    {
        return new RefreshToken(userId, tokenHash, expiresAt, isRevoked, createdAt);
    }

    public void Revoke()
    {
        IsRevoked = true;
    }

    public virtual User User { get; set; } = null!;
}
