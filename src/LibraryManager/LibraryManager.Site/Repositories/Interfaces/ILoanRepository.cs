using LibraryManager.Site.Models;

namespace LibraryManager.Site.Repositories.Interfaces;

public interface ILoanRepository
{
    Task<ResultViewModel<List<LoanViewModel>>> GetAllLoans();
    Task<ResultViewModel<List<LoanViewModel>>> GetAllLoansByUser(Guid idUser);
    Task<ResultViewModel<string>> ReturnBook(Guid idLoan);
    Task<ResultViewModel<Guid>> LoanBook(LoanCreateModel model);
}