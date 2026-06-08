using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Interfaces;
using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Companies.Queries.GetAllCompanies
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, PagedResult<TeamListDto>>
    {
        private readonly IDapperQueryService _queryService;

        public GetAllCompaniesQueryHandler(IDapperQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<PagedResult<TeamListDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _queryService.QueryAsync<TeamListDto>(
                "sp_GetAllCompanies",
                new { request.PageSize, request.Cursor },
                cancellationToken);

            return PagedResult<TeamListDto>.Create(companies.ToList(), request.PageSize, c => c.Id);
        }
    }
}
