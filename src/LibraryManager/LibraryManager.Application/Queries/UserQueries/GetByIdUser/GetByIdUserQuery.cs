using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.UserQueries.GetByIdUser;

public class GetByIdUserQuery : IRequest<ResultViewModel<UserViewModel>>
{
    public GetByIdUserQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}