using FluentValidation;
using LibraryManager.Application.Commands.BookCommands.InsertBook;

namespace LibraryManager.Application.Validators;

public class InsertBookValidator : AbstractValidator<InsertBookCommand>
{
    public InsertBookValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(50)
            .WithMessage("Title must not exceed 50 characters.");
        
        RuleFor(b => b.Author)
            .NotEmpty()
            .WithMessage("Author is required.")
            .MaximumLength(50)
            .WithMessage("Author must not exceed 50 characters.");
        
        RuleFor(b => b.PublicationYear)
            .NotEmpty()
            .WithMessage("Year is required.")
            .GreaterThan(1900)
            .WithMessage("Year must be greater than 1900.");
        
        RuleFor(b => b.ISBN)
            .NotEmpty()
            .WithMessage("ISBN is required.")
            .MaximumLength(10)
            .WithMessage("ISBN must not exceed 10 characters.");
        
        RuleFor(b => b.ImageUrl)
            .NotEmpty()
            .WithMessage("ImageUrl is required.")
            .MaximumLength(500)
            .WithMessage("ImageUrl must not exceed 500 characters.");
        
    }
}