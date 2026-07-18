using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? ProfileImageUrl { get; set; }

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual Role Role { get; set; } = null!;
}
