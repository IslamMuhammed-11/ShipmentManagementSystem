using MediatR;
using ShipmentManagementSystem.Application.Common;


namespace ShipmentManagementSystem.Application.Features.Users.Commands.RegisterUser;

public sealed record RegisterUserCommand(string FirstName, string? SecondName
    , string? ThirdName, string LastName, string Email, string Password, string? PhoneNumber,
    string? ProfileImageUrl, int RoleId) : IRequest<Result<int>>;

