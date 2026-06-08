using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Result<bool>>
    {
        private readonly ITaskRepository _TaskRepository;

        public DeleteTaskCommandHandler(ITaskRepository TaskRepository)
        {
            _TaskRepository = TaskRepository;
        }

        public async Task<Result<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var Task = await _TaskRepository.GetByPublicGuidAsync(request.PublicGuid, cancellationToken);

            if (Task is null)
                return Result<bool>.Failure($"Task with Id '{request.PublicGuid}' not found.");

            _TaskRepository.Remove(Task);
            await _TaskRepository.SaveChangesAsync(cancellationToken);

            return Result<bool>.Success(true);
        }
    }
}
