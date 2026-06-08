using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Common.DTOs
{
    /// <summary>
    /// Search result DTO — 3-table join: Tasks + Companies + TaskCommentCount.
    /// </summary>
    public record TaskSearchDto
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
        public string TeamIndustry { get; init; } = default!;
        public int TaskCommentCount { get; init; }
    }
}
