namespace LibraryManager.Site.Models;

public class ResultViewModel
{
    public bool IsSucces { get; private set; }
    public string Message { get; private set; }

    public ResultViewModel(bool isSucces = true, string message = "")
    {
        IsSucces = isSucces;
        Message = message;
    }

    public static ResultViewModel Success() => new();
    public static ResultViewModel Error(string message) => new(false, message);
}

public class ResultViewModel<T> : ResultViewModel
{
    public T? Data { get; private set; }

    public ResultViewModel(T? data, bool isSucces = true, string message = "")
        : base(isSucces, message)
    {
        Data = data;
    }

    public static ResultViewModel<T> Success(T data) => new(data);
    public static ResultViewModel<T> Error(string message) => new(default, false, message);
}
