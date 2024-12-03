using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;

public interface ILoanRepository
{
    Task<List<Loan>> GetAllAsync();
    Task<List<Loan>> GetAllByUserIdAsync(Guid id);
    Task<Loan?> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(Loan book);
    Task UpdateAsync(Loan book);
}