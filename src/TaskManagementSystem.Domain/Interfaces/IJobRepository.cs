using TaskManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Domain.Interfaces
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<Job?> GetActiveJobByPublicGuidAsync(Guid publicGuid, CancellationToken cancellationToken = default);
    }
}
