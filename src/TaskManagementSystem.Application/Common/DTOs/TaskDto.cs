using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Application.Common.DTOs
{
    public record TaskDto
    {
        public Guid PublicGuid { get; init; } = default!;
        public string Title { get; init; } = default!;
        public string Description { get; init; } = default!;
        public string? Requirements { get; init; }
        public string? AssignedTo { get; init; }
        public string Priority { get; init; } = default!;
        public string Status { get; init; } = default!;
        public DateTime? DueDate { get; init; }
        public int EstimatedHours { get; init; }
        public bool IsRecurring { get; init; }
        public string? RecurrencePattern { get; init; }
        public Guid TeamPublicGuid { get; init; } = default!;
        public string TeamName { get; init; } = default!;
        public DateTime CreatedAt { get; init; }
    }
}
