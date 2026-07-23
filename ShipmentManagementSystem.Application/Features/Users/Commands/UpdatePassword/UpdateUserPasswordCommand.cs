using MediatR;
using ShipmentManagementSystem.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipmentManagementSystem.Application.Features.Users.Commands.UpdatePassword;

public sealed record UpdateUserPasswordCommand(int Id , string CurrentPassword , string NewPassword) : IRequest<Result>;

