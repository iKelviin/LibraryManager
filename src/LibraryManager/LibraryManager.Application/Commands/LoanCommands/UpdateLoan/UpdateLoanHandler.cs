using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.UpdateLoan;

public class UpdateLoanHandler(ILoanRepository loanRepository, IBookRepository bookRepository)
    : IRequestHandler<UpdateLoanCommand, ResultViewModel<string>>
{
    public async Task<ResultViewModel<string>> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await loanRepository.GetByIdAsync(request.Id);
        
        if (loan is null) return ResultViewModel<string>.Error("Loan not found.");
        
        loan.SetAsReturned();
        await loanRepository.UpdateAsync(loan);

        var book = await bookRepository.GetByIdAsync(loan.IdBook);
        book!.ToAvailable();
        await bookRepository.UpdateAsync(book);

        return ResultViewModel<string>.Success($"Book returned! Days overdue: {loan.OverdueDays().ToString()}");
    }
}