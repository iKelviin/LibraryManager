using System.Security.Claims;
using LibraryManager.Site.Models;
using LibraryManager.Site.Security;

namespace LibraryManager.Site.Services.Interfaces;

public interface IAuthService
{
    Task<ResultViewModel<UserViewModel>> Login(User user);
    Task DeleteTokenFromCookie();
    Task<IEnumerable<Claim>?> VerifyUser();
    IEnumerable<Claim>? VerifyUser(string token);
}