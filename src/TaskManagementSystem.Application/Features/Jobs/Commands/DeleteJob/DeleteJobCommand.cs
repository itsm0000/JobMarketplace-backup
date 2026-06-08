using TaskManagementSystem.TaskComment.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Commands.DeleteTask
{
    public record DeleteTaskCommand(Guid PublicGuid) : IRequest<Result<bool>>;
}
