using ShipmentManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class DriverLocationPing
{
    public int Id { get; init; }

    public int DriverId { get; init; }

    public Coordinates Coordinates { get; private set; } = new Coordinates(0, 0);

    public DateTime Timestamp { get; private set; }

    private DriverLocationPing()
    {
    }

    private DriverLocationPing(int driverId,Coordinates coordinates, DateTime timestamp)
    {
        DriverId = driverId;
        Coordinates = coordinates;
        Timestamp = timestamp;
    }

    public static DriverLocationPing Create(int driverId, Coordinates coordinates, DateTime timestamp)
    {
        return new DriverLocationPing(driverId, coordinates, timestamp);
    }

    public void UpdateCoordinates(Coordinates newCoordinates, DateTime timeStamp)
    {
        Coordinates = newCoordinates;
        Timestamp = timeStamp;
    }
    public virtual Driver Driver { get; private set; } = null!;
}
