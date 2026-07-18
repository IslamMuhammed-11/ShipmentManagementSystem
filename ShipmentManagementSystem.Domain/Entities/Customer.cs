using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Customer
{
    public int UserId { get; private set; }

    public string? CompanyName { get; private set; }

    private Customer(int userId, string? companyName)
    {
        UserId = userId;
        CompanyName = companyName;
    }

    public static Customer Create(int userId, string? companyName)
    {
        return new Customer(userId, companyName);
    }

    public static CustomerAddress AddAddress(Customer customer, Address address, string? label, bool isDefault)
    {
        var customerAddress = CustomerAddress.Create(customer.UserId, address.Id, label, isDefault);

        customer.CustomerAddresses.Add(customerAddress);

        return customerAddress;
    }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; private set; } = new List<CustomerAddress>();

    public virtual ICollection<Review> Reviews { get; private set; } = new List<Review>();

    public virtual ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    public virtual User User { get; private set; } = null!;
}
