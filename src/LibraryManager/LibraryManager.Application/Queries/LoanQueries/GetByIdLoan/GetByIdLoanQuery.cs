using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetByIdLoan;

public class GetByIdLoanQuery : IRequest<ResultViewModel<LoanDetailsViewModel>>
{
    public GetByIdLoanQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}