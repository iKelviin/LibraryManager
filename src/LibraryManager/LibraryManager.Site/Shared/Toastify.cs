using Microsoft.JSInterop;

namespace LibraryManager.Site.Shared;

public class Toastify
{
    protected readonly IJSRuntime _JSRuntime;
    public Toastify(IJSRuntime JSRuntime) 
    {
        _JSRuntime = JSRuntime;
    }
    public async Task ShowSucess(string message)
    {
        await _JSRuntime.InvokeVoidAsync("showToastSuccess", message);
    }

    public async Task ShowWarning(string message)
    {
        await _JSRuntime.InvokeVoidAsync("showToastWarning", message);
    }
    public async Task ShowError(string message)
    {
        await _JSRuntime.InvokeVoidAsync("showToastError", message);
    }

    public async Task ShowInfo(string message)
    {
        await _JSRuntime.InvokeVoidAsync("showToastInformation", message);
    }
}