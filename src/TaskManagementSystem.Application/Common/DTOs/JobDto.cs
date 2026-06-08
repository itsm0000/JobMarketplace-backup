using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Common.DTOs
{
    public record TaskDto
    {
        public Guid PublicGuid { get; init; }
        public string Title { get; init; } = default!;
        public string Description { get; init; } = default!;
        public string? Requirements { get; init; }
        public string? Responsibilities { get; init; }
        public string Location { get; init; } = default!;
        public bool IsRemote { get; init; }
        public decimal? SalaryMin { get; init; }
        public decimal? SalaryMax { get; init; }
        public string? SalaryCurrency { get; init; }
        public string TaskType { get; init; } = default!;
        public string ExperienceLevel { get; init; } = default!;
        public string Status { get; init; } = default!;
        public DateTime? ExpiresAt { get; init; }
        public string? Tags { get; init; }
        public Guid TeamPublicGuid { get; init; }
        public string TeamName { get; init; } = default!;
        public DateTime CreatedAt { get; init; }
    }
}
