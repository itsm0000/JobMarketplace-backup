using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Interfaces;
using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Result<TaskDto>>
    {
        private readonly IDapperQueryService _queryService;

        public GetTaskByIdQueryHandler(IDapperQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<Result<TaskDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var Task = await _queryService.QueryFirstOrDefaultAsync<TaskDto>(
                "sp_GetTaskByPublicGuid",
                new { PublicGuid = request.PublicGuid },
                cancellationToken);

            return Task is null
                ? Result<TaskDto>.Failure($"Task with Id '{request.PublicGuid}' not found.")
                : Result<TaskDto>.Success(Task);
        }
    }
}
