using ShipmentManagementSystem.Domain.Enums;

namespace ShipmentManagementSystem.Domain.Entities;

public partial class User
{
    public int Id { get; private set; }

    public string FirstName { get; private set; } = null!;

    public string? SecondName { get; private set; }

    public string? ThirdName { get; private set; }

    public string LastName { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public string PasswordHash { get; private set; } = null!;

    public string? PhoneNumber { get; private set; }

    public string? ProfileImageUrl { get; private set; }

    public int RoleId { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }



    private User()
    {
    }

    private User(string firstName, string? secondName, string? thirdName, string lastName, string email, string passwordHash, string? phoneNumber, string? profileImageUrl, int roleId, bool isActive, DateTime createdAt)
    {
        FirstName = firstName;
        SecondName = secondName;
        ThirdName = thirdName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        ProfileImageUrl = profileImageUrl;
        RoleId = roleId;
        IsActive = isActive;
        CreatedAt = createdAt;
    }

    public static User Create(string firstName, string? secondName, string? thirdName, string lastName, string email, string passwordHash, string? phoneNumber, string? profileImageUrl, int roleId, bool isActive, DateTime createdAt)
    {
        return new User(firstName , secondName , thirdName , lastName ,email, passwordHash, phoneNumber, profileImageUrl, roleId, isActive, createdAt);
    }

    public RefreshToken CreateRefreshToken(string tokenHash, DateTime expiresAt, bool isRevoked, DateTime createdAt)
    {
        var refreshToken = RefreshToken.Create(Id, tokenHash, expiresAt, isRevoked, createdAt);
        RefreshTokens.Add(refreshToken);
        return refreshToken;
    }

    public Customer MakeCustomer(string? companyName)
    {
        var customer = Customer.Create(this.Id, companyName);
        this.Customer = customer;
        return customer;
    }

    public Driver MakeDriver(string licenseNumber, DriverStatus status)
    {
        var driver = Driver.Create(this.Id, licenseNumber, status.ToString());
        this.Driver = driver;
        return driver;
    }

    public Employee MakeEmployee(string department)
    {
        var emp = Employee.Create(this.Id, department);
        this.Employee = emp;
        return emp;
    }

    public void UpdateEmail(string email)
    {
        Email = email;
    }

    public void ChangePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
    }

    public void UpdatePhoneNumber(string? phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public void UpdateProfileImageUrl(string? profileImageUrl)
    {
        ProfileImageUrl = profileImageUrl;
    }

    public void ChangeActiveStatus(bool isActive)
    {
        IsActive = isActive;
    }

    public void ChangeRole(int roleId)
    {
        RoleId = roleId;
    }

    public virtual Customer? Customer { get; private set; }

    public virtual Driver? Driver { get; private set; }

    public virtual Employee? Employee { get; private set; }

    public virtual ICollection<Notification> Notifications { get; private set; } = new List<Notification>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; private set; } = new List<RefreshToken>();

    public virtual Role Role { get; private set; } = null!;
}
