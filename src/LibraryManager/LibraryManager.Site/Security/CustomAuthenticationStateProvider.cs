using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LibraryManager.Site.Models;
using LibraryManager.Site.Services;
using LibraryManager.Site.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace LibraryManager.Site.Security;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IAuthService _authService;
    private readonly CookieService _cookieService;
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
    
    public CustomAuthenticationStateProvider(IAuthService authService, CookieService cookieService)
    {
        _authService = authService;
        _cookieService = cookieService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userClaim = await _authService.VerifyUser();
            if (userClaim != null)
            {
                var identity = new ClaimsIdentity(userClaim, "JWT");
                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return await Task.FromResult(new AuthenticationState(user));
            }
            else
            {
                await _authService.DeleteTokenFromCookie();
                return new AuthenticationState(_anonymous);
            }
        }
        catch (Exception)
        {
            return new AuthenticationState(_anonymous);
        }
    }
    
    

    public async Task<ResultViewModel<UserViewModel>> AuthenticateUser(User userLogin)
    {
        var result = await _authService.Login(userLogin);
        if (result.IsSucces)
        {
            var token = result.Data.Token;
            await _cookieService.SetCookieAsync("auth_token", token, 1);
            
            
            var readJWT = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var identity = new ClaimsIdentity(readJWT.Claims,"JWT");
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return new ResultViewModel<UserViewModel>(result.Data);
        }
        return ResultViewModel<UserViewModel>.Error(result.Message);
    }

    public async Task Logout()
    {
        await _authService.DeleteTokenFromCookie();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
    }
    
    public async Task<Guid> GetUserIdAsync()
    {
        try
        {
            // Obtenha o estado de autenticação
            var authenticationState = await GetAuthenticationStateAsync();

            // Extraia o ID do usuário a partir dos claims
            var userIdClaim = authenticationState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
            {
                return userId;
            }

            // Retorna null se o ID não for encontrado ou não for um GUID válido
            return Guid.Empty;
        }
        catch
        {
            return Guid.Empty;
        }
    }

}