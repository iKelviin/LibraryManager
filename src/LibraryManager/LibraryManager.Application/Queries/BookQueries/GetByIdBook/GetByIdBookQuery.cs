using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetByIdBook;

public class GetByIdBookQuery : IRequest<ResultViewModel<BookDetailsViewModel>>
{
    public GetByIdBookQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}