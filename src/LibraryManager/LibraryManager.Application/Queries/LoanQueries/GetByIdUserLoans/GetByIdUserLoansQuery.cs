using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetByIdUserLoans;

public class GetByIdUserLoansQuery : IRequest<ResultViewModel<List<LoanDetailsViewModel>>>
{
    public GetByIdUserLoansQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}