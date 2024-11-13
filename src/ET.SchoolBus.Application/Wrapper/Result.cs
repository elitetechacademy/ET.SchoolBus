using System;

namespace ET.SchoolBus.Application.Wrapper;

public class Result
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<string> ValidationErrors { get; set; }

    public static Result AddValidationError(List<string> errors) => new Result{ValidationErrors = errors};
    public static Result Success(string message) => new Result{Message = message, IsSuccess=true};
    public static Result Failure(string message) => new Result{Message = message};
}

public class Result<T> : Result
{
    public T Data { get; set; }
    public static Result<T> Success(T data) => new Result<T>{Data = data, IsSuccess = true};
    public static Result<T> Failure(string message) => new Result<T>{Message = message};
}
