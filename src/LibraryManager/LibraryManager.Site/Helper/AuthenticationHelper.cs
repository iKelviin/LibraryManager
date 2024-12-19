using System.Security.Claims;
using LibraryManager.Site.Security;

namespace LibraryManager.Site.Helper;

public class AuthenticationHelper
{
    public static async Task<Guid?> GetAuthenticationUserIdAsync(CustomAuthenticationStateProvider provider)
    {
        var authenticationState = await provider.GetAuthenticationStateAsync();
        var userId = authenticationState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);


        if (userId != null && Guid.TryParse(userId.Value, out var ApplicationUserId))
        {
            return ApplicationUserId;
        }
        return null;
    }
}