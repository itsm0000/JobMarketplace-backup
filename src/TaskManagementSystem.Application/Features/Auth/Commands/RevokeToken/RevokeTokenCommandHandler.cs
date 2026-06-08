using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Auth.Commands.RevokeToken
{
    public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, Result<string>>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RevokeTokenCommandHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<Result<string>> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var storedToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken, cancellationToken);

            if (storedToken is null || !storedToken.IsActive)
                return Result<string>.Failure("Invalid or already revoked token.");

            storedToken.RevokedAt = DateTime.UtcNow;
            await _refreshTokenRepository.SaveChangesAsync(cancellationToken);

            return Result<string>.Success("Token revoked successfully.");
        }
    }
}
