using FluentValidation;
using ShipmentManagementSystem.Application.Features.User.Commands.RegisterUser.Validators;

namespace ShipmentManagementSystem.Application.Features.User.Commands.RegisterUser;

public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(command => command.FirstName)
            .RequiredName().NameMaximumLength(30);


        RuleFor(command => command.SecondName)
            .OptionalName();

        RuleFor(command => command.ThirdName)
            .OptionalName();

        RuleFor(command => command.LastName)
            .RequiredName().NameMaximumLength(30);

        RuleFor(command => command.Email)
            .EmailRequired().EmailInvalid();

        RuleFor(command => command.Password)
            .PasswordRequired().PasswordMinimumLength(8);

        RuleFor(command => command.PhoneNumber)
            .PhoneNumberMaximumLength();

    }



}
