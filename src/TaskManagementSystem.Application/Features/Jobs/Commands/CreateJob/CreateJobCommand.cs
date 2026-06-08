using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Commands.CreateTask
{
    public record CreateTaskCommand : IRequest<Result<Guid>>
    {
        public string Title { get; init; } = default!;
        public string Description { get; init; } = default!;
        public string? Requirements { get; init; }
        public string? Responsibilities { get; init; }
        public string Location { get; init; } = default!;
        public bool IsRemote { get; init; }
        public decimal? SalaryMin { get; init; }
        public decimal? SalaryMax { get; init; }
        public string? SalaryCurrency { get; init; }
        public TaskType TaskType { get; init; }
        public ExperienceLevel ExperienceLevel { get; init; }
        public string? Tags { get; init; }
        public Guid TeamPublicGuid { get; init; }  // API sends the public GUID
    }
}
