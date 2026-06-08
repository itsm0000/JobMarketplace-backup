using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Queries.SearchTasks
{
    public record SearchTasksQuery : IRequest<PagedResult<TaskSearchDto>>
    {
        public string? SearchTerm { get; init; }
        public string? Location { get; init; }
        public string? TaskType { get; init; }
        public string? ExperienceLevel { get; init; }
        public int PageSize { get; init; } = 20;
        public long Cursor { get; init; } = 0;
    }
}
