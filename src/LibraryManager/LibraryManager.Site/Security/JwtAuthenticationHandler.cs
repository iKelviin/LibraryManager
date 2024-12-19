using System.Net.Http.Headers;
using Blazored.LocalStorage;
using LibraryManager.Site.Services;

namespace LibraryManager.Site.Security;

public class JwtAuthenticationHandler : DelegatingHandler
{
    private readonly CookieService _cookieService;

    public JwtAuthenticationHandler(CookieService cookieService)
    {
        _cookieService = cookieService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Obtém o token do cookie
        var token = await _cookieService.GetCookieAsync("auth_token");
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}