using LibraryManager.Site.Models;
using LibraryManager.Site.Security;

namespace LibraryManager.Site.Repositories;

public interface IAuthRepository
{
    Task<ResultViewModel<UserViewModel>> Login(User user);
    Task<ResultViewModel<Guid>> Register(UserCreateModel user);
}