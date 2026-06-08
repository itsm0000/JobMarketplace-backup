using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Common.DTOs
{
    /// <summary>
    /// Trimmed DTO for Team list views — no Description, Website, LogoUrl, Phone.
    /// Full details still available via GetTeamById (which uses TeamDto).
    /// </summary>
    public record TeamListDto
    {
        public long Id { get; init; }
        public Guid PublicGuid { get; init; }
        public string Name { get; init; } = default!;
        public string Industry { get; init; } = default!;
        public string Location { get; init; } = default!;
        public string ContactEmail { get; init; } = default!;
        public int FoundedYear { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
