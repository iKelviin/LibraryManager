using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.UpdateBook;

public class UpdateBookCommand : IRequest<ResultViewModel>
{
    public Guid Id { get;  set; }
    public string Title { get;  set; }
    public string Author { get;  set; }
    public string ISBN { get;  set; }
    public int PublicationYear { get;  set; }
    public string ImageUrl { get; set; }
}