using OperationOOP.Core.Wrappers;

namespace OperationOOP.Api.Endpoints;

public static class ErrorHandler
{
    public static IResult HandleError(Exception ex)
    {
        Console.Error.WriteLine($"[SERVERFEL] {DateTime.Now}: {ex.Message}");

        return Results.Problem("Ett oväntat fel inträffade. Försök igen senare.");
    }

    public static IResult HandleBadRequest(string message)
    {
        Console.Error.WriteLine($"[OGILTIG] {DateTime.Now}: {message}");

        var response = ApiResponse<string>.Fail(message);
        return Results.BadRequest(response);
    }

    public static IResult HandleNotFound(string message)
    {
        Console.Error.WriteLine($"[HITTADES INTE] {DateTime.Now}: {message}");

        var response = ApiResponse<string>.Fail(message);
        return Results.NotFound(response);
    }
}