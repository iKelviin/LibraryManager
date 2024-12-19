using LibraryManager.Site.Models;

namespace LibraryManager.Site.Repositories.Interfaces;

public interface ILoanRepository
{
    Task<ResultViewModel<List<LoanViewModel>>> GetAllLoansByUser(Guid idUser);
    Task<ResultViewModel<string>> ReturnBook(Guid idLoan);
}