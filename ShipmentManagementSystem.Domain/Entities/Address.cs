using ShipmentManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class Address
{


    
    public int Id { get; private set; }

    public string Line1 { get; private set; } = null!;

    public string City { get; private set; } = null!;

    public string? Governorate { get; private set; }

    public string Country { get; private set; } = null!;

    public string? PostalCode { get; private set; }

    public Coordinates? Coordinates { get; private set; }

    private Address(string line1, string city, string country, string? governorate = null, string? postalCode = null, Coordinates? coordinates = null)
    {
        Line1 = line1;
        City = city;
        Country = country;
        Governorate = governorate;
        PostalCode = postalCode;
        Coordinates = coordinates;
    }

    public static Address Create(string line1, string city, string country, string? governorate = null, string? postalCode = null, Coordinates? coordinates = null)
    {
       
        return new Address(line1, city, country, governorate, postalCode, coordinates);
    }


    public virtual ICollection<CustomerAddress> CustomerAddresses { get; private set; } = new List<CustomerAddress>();

    public virtual ICollection<Shipment> ShipmentDeliveryAddresses { get; private set; } = new List<Shipment>();

    public virtual ICollection<Shipment> ShipmentPickupAddresses { get; private set; } = new List<Shipment>();

    public virtual Warehouse? Warehouse { get; private set; }
}



