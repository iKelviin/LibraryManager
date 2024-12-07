namespace LibraryManager.Site.Models;

public class ResultViewModel<T>
{
    private ResultViewModel(T? data, bool isSuccess, string? errorMessage)
    {
        Data = data;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
    
    public bool IsSuccess { get; private set; }
    public T? Data { get; private set; }
    public string? ErrorMessage { get; private set; }

    public static ResultViewModel<T> Success(T data) => new(data, true, null);
    public static ResultViewModel<T> Error(string errorMessage) => new(default, false, errorMessage);
}