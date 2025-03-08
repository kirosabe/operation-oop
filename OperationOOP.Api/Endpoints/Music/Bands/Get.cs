namespace OperationOOP.Api.Endpoints.Music
{
    public class GetBand : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/bands/{id}", Handle)
            .WithSummary("Get a band by Id");

        public record Response(int Id, string Name, string Genre);

        private static IResult Handle(int id, IDatabase db)
        {
            var band = db.Bands.FirstOrDefault(b => b.Id == id);

            if (band == null)
            {
                return Results.NotFound();
            }

            var response = new Response(band.Id, band.Name, band.Genre);
            return Results.Ok(response);
        }
    }
}
