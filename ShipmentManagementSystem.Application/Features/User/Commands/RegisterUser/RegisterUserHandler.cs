using MediatR;
using Org.BouncyCastle.Crypto.Generators;
using ShipmentManagementSystem.Application.Common;
using ShipmentManagementSystem.Domain.Errors;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Application.Features.User.Commands.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<RegisterUserResponse>>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var exist = await _userRepository.DoesUserExistByEmail(request.Email, cancellationToken);

        if (exist)
            return Result<RegisterUserResponse>.Failure(UserErrors.EmailAlreadyExists);

        //HandleProfileImageUpload(request.ProfileImageUrl, cancellationToken);

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        // Handle the registration logic here
        throw new NotImplementedException();
    }
}
