using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Role
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    private Role()
    {
        
    }
    private Role(string name)
    {
        Name = name;
    }

    public static Role Create(string name)
    {
        return new Role(name);
    }
    public virtual ICollection<User> Users { get; private set; } = new List<User>();

    public virtual ICollection<Permission> Permissions { get; private set; } = new List<Permission>();

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if(obj is Role otherRole)
        {
            return Id == otherRole.Id && Name == otherRole.Name;
        }

        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }

}
