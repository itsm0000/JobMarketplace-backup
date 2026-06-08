using TaskManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Domain.Entities
{
    public class TaskComment : BaseAuditableEntity
    {
        public string Content { get; set; } = default!;
        public string? Author { get; set; }

        // Foreign Keys (internal - never exposed in API)
        public long TaskId { get; set; }

        // Navigation
        public Task Task { get; set; } = default!;
    }
}
