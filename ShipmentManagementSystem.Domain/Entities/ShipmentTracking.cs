using ShipmentManagementSystem.Domain.ValueObjects;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class ShipmentTracking
{
    public int Id { get; private set; }

    public int ShipmentId { get; init; }

    public int? WarehouseId { get; private set; }

    public string Status { get; private set; } = null!;

    public Coordinates? Coordinates { get; private set; }

    public string? Notes { get; private set; }

    public DateTime Timestamp { get; private set; }

    private ShipmentTracking()
    {
    }

    private ShipmentTracking(int shipmentId, int? warehouseId, string status, Coordinates coordinates, string? notes, DateTime timestamp)
    {
        ShipmentId = shipmentId;
        WarehouseId = warehouseId;
        Status = status;
        Coordinates = coordinates;
        Notes = notes;
        Notes = notes;
        Timestamp = timestamp;
    }

    public static ShipmentTracking Create(int shipmentId, int? warehouseId, string status, Coordinates coordinates, string? notes, DateTime timestamp)
    {
        return new ShipmentTracking(shipmentId, warehouseId, status, coordinates, notes, timestamp);
    }

    public void UpdateCoordinates(Coordinates newCoordinates , DateTime timeStamp)
    {
        Coordinates = newCoordinates;
        Timestamp = timeStamp;
    }

    public void UpdateStatus(string newStatus , DateTime timeStamp)
    {
        Status = newStatus;
    }

    public void UpdateNotes(string? newNotes , DateTime timeStamp)
    {
        Notes = newNotes;
    }

    public void UpdateWarehouse(int? newWarehouseId , DateTime timeStamp)
    {
        WarehouseId = newWarehouseId;
        Timestamp = timeStamp;
    }

    public virtual Shipment Shipment { get; private set; } = null!;

    public virtual Warehouse? Warehouse { get; private set; }
}
