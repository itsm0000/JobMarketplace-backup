using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Interfaces;
using TaskManagementSystem.TaskComment.Common.Models;
using MediatR;

namespace TaskManagementSystem.TaskComment.Features.TaskComments.Queries.GetTaskCommentsByTask
{
    public class GetTaskCommentsByTaskQueryHandler
           : IRequestHandler<GetTaskCommentsByTaskQuery, PagedResult<TaskCommentListDto>>
    {
        private readonly IDapperQueryService _queryService;

        public GetTaskCommentsByTaskQueryHandler(IDapperQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<PagedResult<TaskCommentListDto>> Handle(
            GetTaskCommentsByTaskQuery request, CancellationToken cancellationToken)
        {
            var TaskComments = await _queryService.QueryAsync<TaskCommentListDto>(
                "sp_GetTaskCommentsByTaskPublicGuid",
                new { request.TaskPublicGuid, request.PageSize, request.Cursor },
                cancellationToken);

            return PagedResult<TaskCommentListDto>.Create(TaskComments.ToList(), request.PageSize, a => a.Id);
        }
    }
}
