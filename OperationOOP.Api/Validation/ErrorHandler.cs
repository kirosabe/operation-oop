using Microsoft.AspNetCore.Http;

namespace OperationOOP.Api.Validation;

public static class ErrorHandler
{
    public static IResult HandleNotFound(string message)
    {
        return Results.NotFound(new { Message = message });
    }

    public static IResult HandleBadRequest(string message)
    {
        return Results.BadRequest(new { Message = message });
    }

    public static IResult HandleInternalServerError(string message)
    {
        return Results.Problem(detail: message);
    }
} 