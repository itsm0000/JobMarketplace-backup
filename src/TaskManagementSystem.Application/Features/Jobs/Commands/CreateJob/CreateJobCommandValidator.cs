using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().MaximumLength(200);

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.Location)
                .NotEmpty().MaximumLength(200);

            RuleFor(x => x.TeamPublicGuid)
                .NotEmpty().WithMessage("Team is required.");

            RuleFor(x => x.SalaryMin)
                .LessThanOrEqualTo(x => x.SalaryMax)
                .When(x => x.SalaryMin.HasValue && x.SalaryMax.HasValue);
        }
    }
}
