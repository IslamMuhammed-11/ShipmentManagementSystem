using MediatR;
using ShipmentManagementSystem.Application.Common;
using ShipmentManagementSystem.Application.Interfaces.Validator;
using ShipmentManagementSystem.Domain.Entities;
using ShipmentManagementSystem.Domain.Errors;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IPhoneNumberChecker _phoneNumberChecker;
    public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher
        , IPhoneNumberChecker phoneNumberChecker)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _phoneNumberChecker = phoneNumberChecker;
    }

    public async Task<Result<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var exist = await _userRepository.DoesUserExistByEmail(request.Email, cancellationToken);

        if (exist)
            return Result<int>.Failure(UserErrors.EmailAlreadyExists);

        //var image = HandleImageUpload(request.ProfileImageUrl, cancellationToken);

        string hashedPassword = _passwordHasher.HashPassword(request.Password);

        bool isPhoneNumberValid = request.PhoneNumber is null ?
            true : _phoneNumberChecker.IsValid(request.PhoneNumber);

        if (!isPhoneNumberValid)
            return Result<int>.Failure(UserErrors.InvalidPhoneNumber);


        var user = User.Create(
            request.FirstName,
            request.SecondName,
            request.ThirdName,
            request.LastName,
            request.Email,
            hashedPassword,
            request.PhoneNumber,
            request.ProfileImageUrl,
            request.RoleId,
            true,
            DateTime.Now
        );

        _userRepository.Add(user);

        await _userRepository.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(user.Id);
    }


}
