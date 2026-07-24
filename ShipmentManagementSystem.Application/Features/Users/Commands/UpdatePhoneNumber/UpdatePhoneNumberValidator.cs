using FluentValidation;
using ShipmentManagementSystem.Application.Features.Users.Commands.RegisterUser.ValidatorExtensions;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.UpdatePhoneNumber;

public class UpdatePhoneNumberValidator : AbstractValidator<UpdatePhoneNumberCommand>
{
    public UpdatePhoneNumberValidator()
    {
        RuleFor(e => e.PhoneNumber).PhoneNumberMaximumLength();
        RuleFor(e => e.Id).GreaterThan(0);
    }
}
