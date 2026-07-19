using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class CustomerAddress
{
    public int CustomerId { get; init; }

    public int AddressId { get; init; }

    public string? Label { get; private set; }

    public bool IsDefault { get; private set; }

    private CustomerAddress(int customerId, int addressId, string? label, bool isDefault)
    {
        CustomerId = customerId;
        AddressId = addressId;
        Label = label;
        IsDefault = isDefault;
    }

    private CustomerAddress()
    {
    }
    internal static CustomerAddress Create(int customerId, int addressId, string? label, bool isDefault)
    {
        return new CustomerAddress(customerId, addressId, label, isDefault);
    }

    public void UpdateLabel(string? label)
    {
        Label = label;
    }

    public void UpdateIsDefault(bool isDefault)
    {
        IsDefault = isDefault;
    }

    public virtual Address Address { get; private set; } = null!;

    public virtual Customer Customer { get; private set; } = null!;
}
