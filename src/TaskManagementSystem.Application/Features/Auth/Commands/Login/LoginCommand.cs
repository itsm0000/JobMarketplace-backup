using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Auth.Commands.Login
{
    public record LoginCommand : IRequest<Result<AuthResponseDto>>
    {
        public string Email { get; init; } = default!;
        public string Password { get; init; } = default!;
    }
}
