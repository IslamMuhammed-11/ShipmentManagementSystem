using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Permission
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    private Permission()
    {
    }

    private Permission(string name)
    {
        Name = name;
    }

    public static Permission Create(string name)
    {
        return new Permission(name);
    }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
