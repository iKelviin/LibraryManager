using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.InsertLoan;

public class InsertLoanCommand : IRequest<ResultViewModel<Guid>>
{
    public InsertLoanCommand(Guid idUser, Guid idBook)
    {
        IdUser = idUser;
        IdBook = idBook;
    }

    public Guid IdUser { get; private set; }
    public Guid IdBook { get; private set; }
    
    public Loan ToEntity() => new(IdUser, IdBook);
}