using TaskManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Domain.Entities
{
    public class Team : BaseAuditableEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? Website { get; set; }
        public string? LogoUrl { get; set; }
        public string Department { get; set; } = default!;
        public string Location { get; set; } = default!;
        public int? MemberCount { get; set; }
        public int FoundedYear { get; set; }
        public string ContactEmail { get; set; } = default!;
        public string? ContactPhone { get; set; }

        // Navigation
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
