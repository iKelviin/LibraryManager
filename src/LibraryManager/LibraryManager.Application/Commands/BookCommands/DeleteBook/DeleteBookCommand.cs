using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.DeleteBook;

public class DeleteBookCommand(Guid id) : IRequest<ResultViewModel>
{
    public Guid id { get; set; } = id;
}