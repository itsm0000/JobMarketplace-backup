using AutoMapper;
using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.TaskComments.Commands.CreateTaskComment
{
    public class CreateTaskCommentCommandHandler
        : IRequestHandler<CreateTaskCommentCommand, Result<Guid>>
    {
        private readonly ITaskTaskCommentRepository _TaskCommentRepository;
        private readonly ITaskRepository _TaskRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommentCommandHandler(
            ITaskTaskCommentRepository TaskCommentRepository,
            ITaskRepository TaskRepository,
            IMapper mapper)
        {
            _TaskCommentRepository = TaskCommentRepository;
            _TaskRepository = TaskRepository;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(
            CreateTaskCommentCommand request, CancellationToken cancellationToken)
        {
            // Resolve the public GUID to the internal Task and verify it's active
            var Task = await _TaskRepository.GetActiveTaskByPublicGuidAsync(
                request.TaskPublicGuid, cancellationToken);

            if (Task is null)
                return Result<Guid>.Failure("Task not found or is no longer accepting TaskComments.");

            var TaskComment = _mapper.Map<TaskTaskComment>(request);
            TaskComment.TaskId = Task.Id;  // Set the internal FK
            TaskComment.AppliedAt = DateTime.UtcNow;

            await _TaskCommentRepository.AddAsync(TaskComment, cancellationToken);
            await _TaskCommentRepository.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(TaskComment.PublicGuid);
        }
    }
}
