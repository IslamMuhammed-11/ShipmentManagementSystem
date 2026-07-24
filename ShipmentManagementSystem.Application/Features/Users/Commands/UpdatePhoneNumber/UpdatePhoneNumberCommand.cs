using MediatR;
using ShipmentManagementSystem.Application.Common;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.UpdatePhoneNumber;

public sealed record UpdatePhoneNumberCommand(int Id, string PhoneNumber) : IRequest<Result>;

