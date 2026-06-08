using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Interfaces;
using TaskManagementSystem.TaskComment.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Queries.SearchTasks
{
    public class SearchTasksQueryHandler : IRequestHandler<SearchTasksQuery, PagedResult<TaskSearchDto>>
    {
        private readonly IDapperQueryService _queryService;

        public SearchTasksQueryHandler(IDapperQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<PagedResult<TaskSearchDto>> Handle(SearchTasksQuery request, CancellationToken cancellationToken)
        {
            // Call SP — returns PageSize + 1 rows so PagedResult can detect if more pages exist
            var Tasks = await _queryService.QueryAsync<TaskSearchDto>(
                "sp_SearchTasks",
                new
                {
                    request.SearchTerm,       // Full-text search (SP auto-formats for CONTAINS)
                    request.Location,         // Optional filter
                    request.TaskType,          // Optional filter
                    request.ExperienceLevel,  // Optional filter
                    request.PageSize,         // How many results per page
                    request.Cursor            // Last Id from previous page (0 = first page)
                },
                cancellationToken);

            // PagedResult trims the extra row, sets HasMore, and grabs NextCursor from the last item's Id
            return PagedResult<TaskSearchDto>.Create(Tasks.ToList(), request.PageSize, j => j.Id);
        }
    }
}
