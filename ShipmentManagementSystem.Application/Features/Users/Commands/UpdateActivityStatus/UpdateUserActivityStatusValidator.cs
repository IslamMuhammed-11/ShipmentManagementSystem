using FluentValidation;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.UpdateActivityStatus;

public class UpdateUserActivityStatusValidator : AbstractValidator<UpdateUserActivityStatusCommand>
{
    public UpdateUserActivityStatusValidator()
    {
        RuleFor(e => e.Id).NotEmpty().GreaterThan(0);
    }
}
