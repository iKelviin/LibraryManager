using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetByIdLoan;

public class GetByIdLoanHandler : IRequestHandler<GetByIdLoanQuery, ResultViewModel<LoanDetailsViewModel>>
{
    private readonly ILoanRepository _repository;

    public GetByIdLoanHandler(ILoanRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<LoanDetailsViewModel>> Handle(GetByIdLoanQuery request, CancellationToken cancellationToken)
    {
        var loan = await _repository.GetByIdAsync(request.Id);
        if (loan is null) return ResultViewModel<LoanDetailsViewModel>.Error("Loan not found.");

        var model = LoanDetailsViewModel.FromEntity(loan);
        return ResultViewModel<LoanDetailsViewModel>.Success(model);
    }
}