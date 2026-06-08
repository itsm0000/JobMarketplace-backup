using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.TaskComments.Commands.CreateTaskComment
{
    public class CreateTaskCommentCommandValidator : AbstractValidator<CreateTaskCommentCommand>
    {
        public CreateTaskCommentCommandValidator()
        {
            RuleFor(x => x.TaskPublicGuid)
                .NotEmpty();

            RuleFor(x => x.ApplicantName)
                .NotEmpty().MaximumLength(150);

            RuleFor(x => x.ApplicantEmail)
                .NotEmpty().EmailAddress();
        }
    }
}
