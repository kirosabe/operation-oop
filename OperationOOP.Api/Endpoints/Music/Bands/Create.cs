
namespace OperationOOP.Api.Endpoints
{
    public class CreateBand : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/bands", Handle)
            .WithSummary("Create a new band");

        public record Request(string Name, string Genre);
        public record Response(int Id);

        private static IResult Handle(Request request, IDatabase db)
        {
            var nameValidationResult = Validator.ValidateNotEmpty(request.Name, "Bandets namn");
            if (nameValidationResult != null) return nameValidationResult;

            var genreValidationResult = Validator.ValidateNotEmpty(request.Genre, "Genren");
            if (genreValidationResult != null) return genreValidationResult;

            try
            {
                var band = new Band(
                    bandId: db.Bands.Any() ? db.Bands.Max(b => b.Id) + 1 : 1,
                    name: request.Name,
                    genre: request.Genre
                );

                db.Bands.Add(band);

                return Results.Ok(new Response(band.Id));
            }
            catch (Exception ex)
            {
                return ErrorHandler.HandleError(ex);
            }
        }
    }
}
