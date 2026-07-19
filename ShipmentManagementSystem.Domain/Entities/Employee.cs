using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Employee
{
    public int UserId { get; private set; }

    public string? Department { get; private set; }

    private Employee()
    {
    }
    private Employee(int userId , string? department)
    {
        UserId = userId;
        Department = department;
    }

    public static Employee Create(int userId, string? department)
    {
        return new Employee(userId, department);
    }

    public void UpdateDepartment(string? department)
    {
        Department = department;
    }
    public virtual ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    public virtual User User { get; private set; } = null!;
}
