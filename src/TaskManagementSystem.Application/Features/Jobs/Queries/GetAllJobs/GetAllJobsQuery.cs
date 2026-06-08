using TaskManagementSystem.TaskComment.Common.DTOs;
using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Queries.GetAllTasks
{
    public record GetAllTasksQuery(int PageSize = 20, long Cursor = 0) : IRequest<PagedResult<TaskListDto>>;
}
