
namespace OperationOOP.Api.Endpoints
{
    public class CreateBand : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/bands", Handle)
            .WithSummary("Create a new band");

        public record Request(string Name, string Genre);
        public record Response(int Id);

        private static Ok<Response> Handle(Request request, IDatabase db)
        {
            var band = new Band(
                bandId: db.Bands.Any() ? db.Bands.Max(b => b.Id) + 1 : 1, 
                name: request.Name,
                genre: request.Genre
            );

            db.Bands.Add(band);

            return TypedResults.Ok(new Response(band.Id));
        }
    }
}
