using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Common.DTOs
{
    /// <summary>
    /// Lightweight DTO for streaming export — no Id (not needed by consumers).
    /// </summary>
    public record TaskExportDto
    {
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
        public string TeamName { get; init; } = default!;
        public string TeamIndustry { get; init; } = default!;
    }
}
