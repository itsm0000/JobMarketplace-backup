using TaskManagementSystem.TaskComment.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Auth.Commands.RevokeToken
{
    public record RevokeTokenCommand : IRequest<Result<string>>
    {
        public string RefreshToken { get; init; } = default!;
    }
}
