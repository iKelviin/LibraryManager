using Microsoft.JSInterop;

namespace LibraryManager.Site.Services;

public class CookieService
{
    private readonly IJSRuntime JSRuntime;

    public CookieService(IJSRuntime jsRuntime)
    {
        JSRuntime = jsRuntime;
    }

    public async Task<string> GetCookieAsync(string name)
    {
        return await JSRuntime.InvokeAsync<string>("getCookie", name);
    }

    public async Task SetCookieAsync(string name, string value, int days)
    {
        await JSRuntime.InvokeVoidAsync("setCookie", name, value, days);
    }

    public async Task DeleteCookieAsync(string name)
    {
        await JSRuntime.InvokeVoidAsync("deleteCookie", name);
    }
}