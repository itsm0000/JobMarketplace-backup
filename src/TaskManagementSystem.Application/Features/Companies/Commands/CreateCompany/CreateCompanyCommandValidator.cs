using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.TaskComment.Features.Companies.Commands.CreateTeam
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Team name is required.")
                .MaximumLength(200);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Industry)
                .NotEmpty().WithMessage("Industry is required.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.");

            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("Contact email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.FoundedYear)
                .InclusiveBetween(1800, DateTime.UtcNow.Year);

            RuleFor(x => x.Website)
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .When(x => !string.IsNullOrEmpty(x.Website))
                .WithMessage("Invalid URL format.");
        }
    }
}
