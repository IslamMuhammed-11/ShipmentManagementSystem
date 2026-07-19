using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Driver
{
    public int UserId { get; private set; }

    public string LicenseNumber { get; private set; } = null!;

    public string AvailabilityStatus { get; private set; } = null!;

    private Driver(int userId, string licenseNumber, string availabilityStatus)
    {
        UserId = userId;
        LicenseNumber = licenseNumber;
        AvailabilityStatus = availabilityStatus;
    }

    public static Driver Create(int userId, string licenseNumber, string availabilityStatus)
    {
        return new Driver(userId, licenseNumber, availabilityStatus);
    }
    private Driver()
    {
    }

    public void UpdateAvailabilityStatus(string availabilityStatus)
    {
        AvailabilityStatus = availabilityStatus;
    }

    public void UpdateLicenseNumber(string licenseNumber)
    {
        LicenseNumber = licenseNumber;
    }

    public virtual ICollection<DriverLocationPing> DriverLocationPings { get; private set; } = new List<DriverLocationPing>();

    public virtual ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    public virtual User User { get; private set; } = null!;

    public virtual ICollection<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
}
