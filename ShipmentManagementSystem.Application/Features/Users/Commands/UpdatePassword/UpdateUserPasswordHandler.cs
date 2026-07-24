using MediatR;
using ShipmentManagementSystem.Application.Common;
using ShipmentManagementSystem.Application.Interfaces.Validator;
using ShipmentManagementSystem.Domain.Errors;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.UpdatePassword;

public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPasswordCommand, Result>
{

    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UpdateUserPasswordHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user == null)
            return Result.Failure(UserErrors.UserNotFound(request.Id));

        bool verify = _passwordHasher.VerifyPassword(request.CurrentPassword, user.PasswordHash);

        if (!verify)
            return Result.Failure(UserErrors.InvalidCreds);

        string newPasswordHash = _passwordHasher.HashPassword(request.NewPassword);

        user.ChangePassword(newPasswordHash);

        await _userRepository.SaveChangesAsync();

        return Result.Success();
    }
}
