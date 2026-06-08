using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Companies.Queries.GetTeamById
{
    public record GetTeamByIdQuery(Guid PublicGuid) : IRequest<Result<TeamDto>>;
}
