using OperationOOP.Api.Endpoints;

namespace OperationOOP.Api.Validation;

public static class Validator
{
    public static IResult? ValidateId(int id, string parameterName)
    {
        if (id <= 0)
        {
            return ErrorHandler.HandleBadRequest($"{parameterName} måste vara ett positivt heltal.");
        }

        return null;
    }

    public static IResult? ValidateNotEmpty(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ErrorHandler.HandleBadRequest($"{parameterName} får inte vara tomt.");
        }

        return null;
    }

    public static IResult? ValidatePositiveDuration(int durationInSeconds)
    {
        if (durationInSeconds <= 0)
        {
            return ErrorHandler.HandleBadRequest("Längden måste vara mer än 0 sekunder.");
        }

        return null;
    }
}