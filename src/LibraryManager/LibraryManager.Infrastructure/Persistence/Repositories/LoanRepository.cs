using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistence.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly LibraryManagerDbContext _context;
    public LoanRepository(LibraryManagerDbContext context)
    {
        _context = context;
    }
    public async Task<List<Loan>> GetAllAsync()
    {
        var loans = await _context.Loans
            .Where(l => !l.IsDeleted)
            .Include(b => b.Book)
            .Include(u => u.User)
            .ToListAsync();
        return loans;
    }

    public async Task<List<Loan>> GetAllByUserIdAsync(Guid id)
    {
        var loans = await _context.Loans
            .Where(l => !l.IsDeleted && l.IdUser == id)
            .Include(b => b.Book)
            .Include(u => u.User)
            .ToListAsync();
        return loans;
    }

    public Task<Loan?> GetByIdAsync(Guid id)
    {
        var loan = _context.Loans
            .Where(l => !l.IsDeleted)
            .Include(b => b.Book)
            .Include(u => u.User)
            .SingleOrDefaultAsync(l => l.Id == id);
        return loan;
    }

    public async Task<Guid> AddAsync(Loan loan)
    {
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
        return loan.Id;
    }

    public async Task UpdateAsync(Loan loan)
    {
        _context.Loans.Update(loan);
        await _context.SaveChangesAsync();
    }
}