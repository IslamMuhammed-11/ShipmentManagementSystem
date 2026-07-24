namespace ShipmentManagementSystem.Application.Interfaces.Validator;

public interface IPhoneNumberChecker
{
    public bool IsValid(string phoneNumber, string? region = null);
}
