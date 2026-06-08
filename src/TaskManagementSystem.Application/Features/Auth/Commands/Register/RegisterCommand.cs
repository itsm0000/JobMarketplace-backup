using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Auth.Commands.Register
{
    public record RegisterCommand : IRequest<Result<AuthResponseDto>>
    {
        public string Email { get; init; } = default!;
        public string Password { get; init; } = default!;
        public string FirstName { get; init; } = default!;
        public string LastName { get; init; } = default!;
        public UserRole Role { get; init; } = UserRole.TaskSeeker;
    }
}
