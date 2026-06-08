using TaskManagementSystem.TaskComment.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Companies.Commands.CreateTeam
{
    public record CreateTeamCommand : IRequest<Result<Guid>>
    {
        public string Name { get; init; } = default!;
        public string Description { get; init; } = default!;
        public string? Website { get; init; }
        public string Industry { get; init; } = default!;
        public string Location { get; init; } = default!;
        public int? EmployeeCount { get; init; }
        public int FoundedYear { get; init; }
        public string ContactEmail { get; init; } = default!;
        public string? ContactPhone { get; init; }
    }
}
