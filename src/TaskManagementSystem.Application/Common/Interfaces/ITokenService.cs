using TaskManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
