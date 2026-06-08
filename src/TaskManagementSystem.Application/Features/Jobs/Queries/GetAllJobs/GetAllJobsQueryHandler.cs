using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Interfaces;
using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, PagedResult<TaskListDto>>
    {
        private readonly IDapperQueryService _queryService;

        public GetAllTasksQueryHandler(IDapperQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<PagedResult<TaskListDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var Tasks = await _queryService.QueryAsync<TaskListDto>(
                "sp_GetAllTasks",
                new { request.PageSize, request.Cursor },
                cancellationToken);

            return PagedResult<TaskListDto>.Create(Tasks.ToList(), request.PageSize, j => j.Id);
        }
    }
}
