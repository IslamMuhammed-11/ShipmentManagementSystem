using FluentValidation;
using ShipmentManagementSystem.Application.Features.Users.Commands.RegisterUser.ValidatorExtensions;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.UpdatePassword;

public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordValidator()
    {
        RuleFor(e => e.NewPassword).PasswordRequired().PasswordMinimumLength(8);
        RuleFor(e => e.CurrentPassword).PasswordRequired();
        RuleFor(e => e.Id).NotEmpty().GreaterThan(0);
    }
}
