using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetAllLoans;

public class GetAllLoansQuery : IRequest<ResultViewModel<List<LoanViewModel>>>
{
    
}