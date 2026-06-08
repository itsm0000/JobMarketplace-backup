using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Common.DTOs
{
    /// <summary>
    /// Trimmed DTO for Task list views — no Description, Requirements, Responsibilities, Tags.
    /// Full details are still available via GetTaskById (which uses TaskDto).
    /// </summary>
    public record TaskListDto
    {
        public long Id { get; init; }
        public Guid PublicGuid { get; init; }
        public string Title { get; init; } = default!;
        public string Location { get; init; } = default!;
        public bool IsRemote { get; init; }
        public decimal? SalaryMin { get; init; }
        public decimal? SalaryMax { get; init; }
        public string? SalaryCurrency { get; init; }
        public string TaskType { get; init; } = default!;
        public string ExperienceLevel { get; init; } = default!;
        public DateTime CreatedAt { get; init; }
        public Guid TeamPublicGuid { get; init; }
        public string TeamName { get; init; } = default!;
    }
}
