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

    public async Task<ConfirmResult> ShowConfirmChanges(string changeData)
    {
        return await _JSRuntime.InvokeAsync<ConfirmResult>("ConfirmChange", changeData);
    }
    
    public async Task<ConfirmResult> ShowConfirmLoan(string bookTitle)
    {
        return await _JSRuntime.InvokeAsync<ConfirmResult>("ConfirmLoanBook", bookTitle);
    }
    public async Task<ConfirmResult> ShowConfirmReturnBook(string bookTitle)
    {
        return await _JSRuntime.InvokeAsync<ConfirmResult>("ConfirmReturnBook", bookTitle);
    }
    
    public async Task ShowLoanSucess()
    {
        await _JSRuntime.InvokeVoidAsync("LoanSuccess");
    }

    public async Task ShowSaveSucess()
    {
        await _JSRuntime.InvokeVoidAsync("SaveSuccess");
    }

    public async Task ShowArchiveSucess()
    {
        await _JSRuntime.InvokeVoidAsync("ArchiveSuccess");
    }
    public async Task ShowAvailableSucess()
    {
        await _JSRuntime.InvokeVoidAsync("AvailableSuccess");
    }

    public async Task ShowReturnSucess()
    {
        await _JSRuntime.InvokeVoidAsync("ReturnBookSuccess");
    }
}