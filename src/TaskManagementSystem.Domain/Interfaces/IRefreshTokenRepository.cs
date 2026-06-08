using TaskManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Domain.Interfaces
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default);
        Task RevokeAllUserTokensAsync(long userId, CancellationToken cancellationToken = default);
    }
}
