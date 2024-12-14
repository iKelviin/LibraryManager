using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(User user);
    Task UpdateAsync(User user);
    Task<User?> GetUserByEmailAndPassword(string email, string password);
    Task<bool> Exists(string email);
}