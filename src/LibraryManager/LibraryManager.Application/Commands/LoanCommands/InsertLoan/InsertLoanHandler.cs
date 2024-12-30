using LibraryManager.Application.Models;
using LibraryManager.Core.Enums;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.InsertLoan;

public class InsertLoanHandler : IRequestHandler<InsertLoanCommand, ResultViewModel<Guid>>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;

    public InsertLoanHandler(ILoanRepository repository, IBookRepository bookRepository, IUserRepository userRepository)
    {
        _loanRepository = repository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Guid>> Handle(InsertLoanCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.IdUser);
        if(user == null) return ResultViewModel<Guid>.Error("User does not exist.");
        
        var book = await _bookRepository.GetByIdAsync(request.IdBook);
        if (book == null) return ResultViewModel<Guid>.Error("Book not found.");
        
        if(book.Status != BookStatus.Available) return ResultViewModel<Guid>.Error("Book is not available.");
        
        book.ToLoan();
        await _bookRepository.UpdateAsync(book);
        
        
        var loan = request.ToEntity();
        await _loanRepository.AddAsync(loan);
        return new ResultViewModel<Guid>(loan.Id);
    }
}