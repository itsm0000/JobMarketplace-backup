using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Auth.Commands.RefreshToken
{
    public record RefreshTokenCommand : IRequest<Result<AuthResponseDto>>
    {
        public string RefreshToken { get; init; } = default!;
    }
}
