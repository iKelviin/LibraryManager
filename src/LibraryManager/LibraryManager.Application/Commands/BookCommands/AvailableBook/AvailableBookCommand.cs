using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.AvailableBook;

public class AvailableBookCommand : IRequest<ResultViewModel>
{
    public AvailableBookCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}