using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetByIdUserLoans;

public class GetByIdUserLoansHandler : IRequestHandler<GetByIdUserLoansQuery, ResultViewModel<List<LoanViewModel>>>
{
    private readonly ILoanRepository _repository;

    public GetByIdUserLoansHandler(ILoanRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetByIdUserLoansQuery request, CancellationToken cancellationToken)
    {
        var loans = await _repository.GetAllByUserIdAsync(request.Id);
        
        var model = loans.Select(LoanViewModel.FromEntity).ToList();
        
        return new ResultViewModel<List<LoanViewModel>>(model);
    }
}