namespace OperationOOP.Core.Wrappers;

using System;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }

    public ApiResponse() { }

    public ApiResponse(T data, string message = "Lyckades")
    {
        Data = data;
        Message = message;
        Success = true;
    }

    public ApiResponse(string message)
    {
        Message = message;
        Success = false;
    }

    public static ApiResponse<T> Ok(T data, string message = "Lyckades") => new(data, message);

    public static ApiResponse<T> Fail(string message) => new(message);
}