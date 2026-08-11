namespace Play.cleanarch.Application;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string? Error { get; }

    // TODO: private constructor taking (bool isSuccess, T? value, string? error) — assign to the three properties above

    // TODO: public static Result<T> Success(T value)
    //       -> new Result<T> with IsSuccess = true, Value = value, Error = null
    // TODO: public static Result<T> Failure(string error)
    //       -> new Result<T> with IsSuccess = false, Value = default, Error = error
}
