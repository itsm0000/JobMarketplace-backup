using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Interfaces;
using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Companies.Queries.GetTeamById
{
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, Result<TeamDto>>
    {
        private readonly IDapperQueryService _queryService;

        public GetTeamByIdQueryHandler(IDapperQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<Result<TeamDto>> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var Team = await _queryService.QueryFirstOrDefaultAsync<TeamDto>(
                "sp_GetTeamByPublicGuid",
                new { PublicGuid = request.PublicGuid },
                cancellationToken);

            return Team is null
                ? Result<TeamDto>.Failure($"Team with Id '{request.PublicGuid}' not found.")
                : Result<TeamDto>.Success(Team);
        }
    }
}
