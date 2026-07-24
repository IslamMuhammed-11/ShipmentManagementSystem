using MediatR;
using ShipmentManagementSystem.Application.Common;
using ShipmentManagementSystem.Application.Interfaces.Validator;
using ShipmentManagementSystem.Domain.Errors;
using ShipmentManagementSystem.Domain.Interfaces;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.UpdatePhoneNumber;

public class UpdatePhoneNumberHandler : IRequestHandler<UpdatePhoneNumberCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IPhoneNumberChecker _phoneNumberChecker;

    public UpdatePhoneNumberHandler(IUserRepository userRepository
                                        , IPhoneNumberChecker phoneNumberChecker)
    {
        _userRepository = userRepository;
        _phoneNumberChecker = phoneNumberChecker;
    }

    public async Task<Result> Handle(UpdatePhoneNumberCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user == null)
            return Result.Failure(UserErrors.UserNotFound(request.Id));

        if (!_phoneNumberChecker.IsValid(request.PhoneNumber))
            return Result.Failure(UserErrors.InvalidPhoneNumber);

        user.UpdatePhoneNumber(request.PhoneNumber);

        await _userRepository.SaveChangesAsync();

        return Result.Success();
    }


}
