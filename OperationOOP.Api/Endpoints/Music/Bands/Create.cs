
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
            if (string.IsNullOrEmpty(request.Name))
            {
                return Results.BadRequest("Bandets namn kan inte vara tomt.");
            }

            if (string.IsNullOrEmpty(request.Genre))
            {
                return Results.BadRequest("Genren kan inte vara tom.");
            }

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
                Console.Error.WriteLine($"Fel vid skapande av band: {ex.Message}");
                return Results.Problem("Ett oväntat fel inträffade vid skapandet av bandet.");
            }
        }
    }
}
