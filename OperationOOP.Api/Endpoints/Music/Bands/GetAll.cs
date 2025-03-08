namespace OperationOOP.Api.Endpoints.Music
{
    public class GetAllBands : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/bands", Handle)
            .WithSummary("Get all bands");

        public record Response(int Id, string Name, string Genre);

        private static IResult Handle(IDatabase db)
        {
            var response = db.Bands.Select(b => new Response(b.Id, b.Name, b.Genre)).ToList();
            return Results.Ok(response);
        }
    }
}
