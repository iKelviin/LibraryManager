using LibraryManager.Site.Models;
using LibraryManager.Site.Repositories.Interfaces;
using LibraryManager.Site.Services.Interfaces;

namespace LibraryManager.Site.Services;

public class LoanService : ILoanService
{
    private readonly ILoanRepository _loanRepository;

    public LoanService(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<ResultViewModel<List<LoanViewModel>>> GetAllLoansByUser(Guid idUser, string searchWord)
    {
        var result = await _loanRepository.GetAllLoansByUser(idUser);
        if(!result.IsSucces) return ResultViewModel<List<LoanViewModel>>.Error(result.Message);

        var loans = result.Data!;
        if (!string.IsNullOrEmpty(searchWord))
        {
            loans = loans.FindAll(x=> x.BookTitle.ToLower().Contains(searchWord.ToLower()) ||
                                      x.BookAuthor.ToLower().Contains(searchWord.ToLower()));
        }
       
        return ResultViewModel<List<LoanViewModel>>.Success(loans);
    }

    public async Task<ResultViewModel<string>> ReturnBook(Guid idLoan)
    {
        return await _loanRepository.ReturnBook(idLoan);
    }
}