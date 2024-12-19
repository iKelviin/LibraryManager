using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LibraryManager.Site.Models;
using LibraryManager.Site.Repositories;
using LibraryManager.Site.Security;
using LibraryManager.Site.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManager.Site.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly CookieService _cookieService;
    private string Key = "Essa Aqui é a Minha Chave Secreta Para Proteger Meus Tokens!";
    private string Issuer = "LibraryManager";
    private string Audience = "Users";

    public AuthService(IAuthRepository authRepository, CookieService cookieService)
    {
        _authRepository = authRepository;
        _cookieService = cookieService;
    }

    public async Task<ResultViewModel<UserViewModel>> Login(User user)
    {
        return await _authRepository.Login(user);
    }

    public async Task DeleteTokenFromCookie()
    {
        await _cookieService.DeleteCookieAsync("auth_token");
    }

    public async Task<IEnumerable<Claim>?> VerifyUser()
    {
        var token = await _cookieService.GetCookieAsync("auth_token");
        if (token is null) return null;

        return VerifyUser(token);
    }

    public IEnumerable<Claim>? VerifyUser(string token)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Issuer,
            ValidAudience = Audience,
            IssuerSigningKey = securityKey
        };

        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            var jsonToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            if (jsonToken != null)
            {
                return jsonToken.Claims.ToList();
            }
        }
        catch (Exception)
        {
        }

        return null;
    }
}