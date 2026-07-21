using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

    private Customer()
    {
    }

    internal static Customer Create(int userId, string? companyName)
    {
        return new Customer(userId, companyName);
    }

    public CustomerAddress AddAddress(Address address, string? label, bool isDefault)
    {
        var customerAddress = CustomerAddress.Create(this.UserId, address.Id, label, isDefault);

        CustomerAddresses.Add(customerAddress);

        return customerAddress;
    }


    public Review AddReview(Shipment shipment, byte rating, string? comment , DateTime createdAt)
    {
        var review = Review.Create(shipment.Id , UserId , rating , comment , createdAt);
        Reviews.Add(review);
        return review;
    }

    public void UpdateCompanyName(string? companyName)
    {
        CompanyName = companyName;
    }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; private set; } = new List<CustomerAddress>();

    public virtual ICollection<Review> Reviews { get; private set; } = new List<Review>();

    public virtual ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    public virtual User User { get; private set; } = null!;
}
