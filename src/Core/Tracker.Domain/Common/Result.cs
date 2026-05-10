using System.Diagnostics.Contracts;

namespace Tracker.Domain.Common;

public class Result
{
    public bool IsSuccess { get; private set; }
    public string? Error { get; private set; }
    public IEnumerable<string> Errors { get; private set; }

    protected internal Result(bool isSuccess, string? error, IEnumerable<string>? errors = null)
    {
        IsSuccess = isSuccess;
        Error = error;
        Errors = errors ?? [];
    }

    public static Result<T> Failure<T>(string error) => new(false, default, error);
    public static Result<T> Failure<T>(IEnumerable<string> errors) => new(false, default, null, errors);
    public static Result<T> Success<T>(T value) => new(true, value, null);
}

public class Result<T> : Result
{
    public T? Value { get; }

    protected internal Result(bool isSuccess, T? value, string? error, IEnumerable<string>? errors = null)
        : base(isSuccess, error, errors)
    {
        Value = value;
    }
}
