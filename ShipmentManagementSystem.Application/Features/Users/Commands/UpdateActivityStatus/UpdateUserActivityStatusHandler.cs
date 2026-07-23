using MediatR;
using ShipmentManagementSystem.Application.Common;
using ShipmentManagementSystem.Domain.Interfaces;
using ShipmentManagementSystem.Domain.Errors;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.UpdateActivityStatus;

public class UpdateUserActivityStatusHandler : IRequestHandler<UpdateUserActivityStatusCommand , Result>
{

    private readonly IUserRepository _userRepository;

    public UpdateUserActivityStatusHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result> Handle(UpdateUserActivityStatusCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user == null)
            return Result.Failure(UserErrors.UserNotFound(request.Id));

        user.ChangeActiveStatus(request.IsActive);

        await _userRepository.SaveChangesAsync();

        return Result.Success();
    }
}
