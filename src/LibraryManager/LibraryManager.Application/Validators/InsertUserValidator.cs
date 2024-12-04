using FluentValidation;
using LibraryManager.Application.Commands.UserCommands.InsertUser;

namespace LibraryManager.Application.Validators;

public class InsertUserValidator : AbstractValidator<InsertUserCommand>
{
    public InsertUserValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress();

        RuleFor(u => u.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(50)
            .WithMessage("Name must not exceed 50 characters");

    }
}