namespace OperationOOP.Api.Endpoints
{
    public static class ErrorHandler
    {
        public static IResult HandleError(Exception ex)
        {
            Console.Error.WriteLine($"Ett oväntat fel inträffade: {ex.Message}");

            return Results.Problem("Ett oväntat fel inträffade. Försök igen senare.");
        }
        public static IResult HandleBadRequest(string message)
        {
            Console.Error.WriteLine($"Felaktig begäran: {message}");

            return Results.BadRequest(message);
        }
    }
}
