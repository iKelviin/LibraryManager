using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.UpdateLoan;

public class UpdateLoanCommand : IRequest<ResultViewModel<string>>
{
    public UpdateLoanCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}