using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Result<bool>>
    {
        private readonly ITaskRepository _TaskRepository;

        public UpdateTaskCommandHandler(ITaskRepository TaskRepository)
        {
            _TaskRepository = TaskRepository;
        }

        public async Task<Result<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var Task = await _TaskRepository.GetByPublicGuidAsync(request.PublicGuid, cancellationToken);

            if (Task is null)
                return Result<bool>.Failure($"Task with Id '{request.PublicGuid}' not found.");

            Task.Title = request.Title;
            Task.Description = request.Description;
            Task.Requirements = request.Requirements;
            Task.Location = request.Location;
            Task.IsRemote = request.IsRemote;
            Task.SalaryMin = request.SalaryMin;
            Task.SalaryMax = request.SalaryMax;
            Task.TaskType = request.TaskType;
            Task.ExperienceLevel = request.ExperienceLevel;
            Task.Status = request.Status;

            _TaskRepository.Update(Task);
            await _TaskRepository.SaveChangesAsync(cancellationToken);

            return Result<bool>.Success(true);
        }
    }
}
