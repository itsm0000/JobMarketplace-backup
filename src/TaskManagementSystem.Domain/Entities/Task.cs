using TaskManagementSystem.Domain.Common;
using TaskManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Domain.Entities
{
    public class Task : BaseAuditableEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? Requirements { get; set; }
        public string? AssignedTo { get; set; }
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public TaskStatus Status { get; set; } = TaskStatus.ToDo;
        public DateTime? DueDate { get; set; }
        public int EstimatedHours { get; set; }
        public bool IsRecurring { get; set; } // Unique feature: Recurring tasks
        public string? RecurrencePattern { get; set; } // e.g., "daily", "weekly", "monthly"

        // Foreign Keys (internal - never exposed in API)
        public long TeamId { get; set; }

        // Navigation
        public Team Team { get; set; } = default!;
        public ICollection<TaskComment> Comments { get; set; } = new List<TaskComment>();
    }
}
