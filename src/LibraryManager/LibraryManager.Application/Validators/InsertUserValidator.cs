using System.Text.RegularExpressions;
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
            .NotNull()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not valid");

        RuleFor(u => u.Name)
            .NotEmpty()
            .WithMessage("Email is required")
            .NotNull()
            .WithMessage("Name is required")
            .MaximumLength(50)
            .WithMessage("Name must not exceed 50 characters");

        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .Must(ValidatePassword)
            .WithMessage("Password must be 8 characters or more, one number, one uppercase letter, one lowercase letter, one special character");
    }

    public bool ValidatePassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
        return regex.IsMatch(password);
    }
}