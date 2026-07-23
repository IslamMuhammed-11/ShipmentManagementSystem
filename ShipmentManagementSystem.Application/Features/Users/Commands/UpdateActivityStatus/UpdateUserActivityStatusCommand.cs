using MediatR;
using ShipmentManagementSystem.Application.Common;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.UpdateActivityStatus;

public sealed record UpdateUserActivityStatusCommand(int Id , bool IsActive) : IRequest<Result>;

