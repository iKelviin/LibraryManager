using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.ArchiveBook;

public class ArchiveBookCommand : IRequest<ResultViewModel>
{
    public ArchiveBookCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}