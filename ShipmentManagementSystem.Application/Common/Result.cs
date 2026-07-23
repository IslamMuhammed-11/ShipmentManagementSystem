using ShipmentManagementSystem.Domain.Errors;

#pragma warning disable CS0108

namespace ShipmentManagementSystem.Application.Common;

public class Result
{
    public bool IsSuccess { get; private set; }

    public Error? Error { get; private set; }

    protected Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, null);

    public static Result Failure(Error error) => new Result(false, error);
}


public class Result<T> : Result
{
    public T? Value { get; private set; }

    protected Result(T? value, bool isSuccess, Error? error) : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, null);

    public static Result<T> Failure(Error? error) => new Result<T>(default, false, error);
}
