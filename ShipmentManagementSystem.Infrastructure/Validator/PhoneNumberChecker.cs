using Microsoft.Extensions.Logging;
using PhoneNumbers;
using ShipmentManagementSystem.Application.Interfaces.Validator;

namespace ShipmentManagementSystem.Infrastructure.Validator;

public class PhoneNumberChecker : IPhoneNumberChecker
{
    private readonly ILogger<PhoneNumberChecker> _logger;

    public PhoneNumberChecker(ILogger<PhoneNumberChecker> logger)
    {
        _logger = logger;
    }

    public bool IsValid(string PhoneNumber, string? Region = null)
    {
        try
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var phoneNumber = phoneNumberUtil.Parse(PhoneNumber, Region);

            var isValid = phoneNumberUtil.IsValidNumber(phoneNumber);

            return isValid;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return false;
        }
    }

}
