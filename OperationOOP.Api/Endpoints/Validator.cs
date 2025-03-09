namespace OperationOOP.Api.Endpoints
{
    public static class Validator
    {
        public static IResult ValidateId(int id, string parameterName)
        {
            if (id <= 0)
            {
                return ErrorHandler.HandleBadRequest($"{parameterName} måste vara ett positivt tal.");
            }
            return null;
        }

        public static IResult ValidateNotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                return ErrorHandler.HandleBadRequest($"{parameterName} kan inte vara tomt.");
            }
            return null;
        }
    }
}
