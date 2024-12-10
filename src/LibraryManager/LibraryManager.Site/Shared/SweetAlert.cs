using Microsoft.JSInterop;

namespace LibraryManager.Site.Shared;

public class SweetAlert
{
    protected readonly IJSRuntime _JSRuntime;
    public SweetAlert(IJSRuntime JSRuntime)
    {
        _JSRuntime = JSRuntime;
    }
    public async Task ShowDeleteSucess()
    {
        await _JSRuntime.InvokeVoidAsync("DeleteSuccess");
    }

    public async Task<ConfirmResult> ShowConfirmDelete()
    {
        return await _JSRuntime.InvokeAsync<ConfirmResult>("ConfirmDelete");
    }

    public async Task ShowSaveSucess()
    {
        await _JSRuntime.InvokeVoidAsync("SaveSuccess");
    }
}