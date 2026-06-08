using AutoMapper;
using TaskManagementSystem.TaskComment.Common.Models;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Enums;
using TaskManagementSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<Guid>>
    {
        private readonly ITaskRepository _TaskRepository;
        private readonly ITeamRepository _TeamRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(
            ITaskRepository TaskRepository,
            ITeamRepository TeamRepository,
            IMapper mapper)
        {
            _TaskRepository = TaskRepository;
            _TeamRepository = TeamRepository;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            // Resolve the public GUID to the internal ID
            var Team = await _TeamRepository.GetByPublicGuidAsync(
                request.TeamPublicGuid, cancellationToken);

            if (Team is null)
                return Result<Guid>.Failure($"Team with Id '{request.TeamPublicGuid}' not found.");

            var Task = _mapper.Map<Task>(request);
            Task.TeamId = Team.Id;  // Set the internal FK
            Task.Status = TaskStatus.Active;

            await _TaskRepository.AddAsync(Task, cancellationToken);
            await _TaskRepository.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(Task.PublicGuid);
        }
    }
}
