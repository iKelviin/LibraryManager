using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LibraryManagerDbContext _context;
    public UserRepository(LibraryManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.Where(u => !u.IsDeleted).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await _context.Users
            .Include(u => u.Loans)
            .ThenInclude(l => l.Book)
            .Where(u => !u.IsDeleted)
            .SingleOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<Guid> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmailAndPassword(string email, string password)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
    }

    public async Task<bool> Exists(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}