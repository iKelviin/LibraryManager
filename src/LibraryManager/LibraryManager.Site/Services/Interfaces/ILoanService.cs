using LibraryManager.Site.Models;

namespace LibraryManager.Site.Services.Interfaces;

public interface ILoanService
{
    Task<ResultViewModel<List<LoanViewModel>>> GetAllLoans(string searchWord);
    Task<ResultViewModel<List<LoanViewModel>>> GetAllLoansByUser(Guid idUser, string searchWord);
    Task<ResultViewModel<string>> ReturnBook(Guid idLoan);
    Task<ResultViewModel<Guid>> LoanBook(LoanCreateModel model);
}