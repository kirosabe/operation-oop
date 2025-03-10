namespace OperationOOP.Api.Endpoints.Bands
{
    public class GetBandsWithoutGenre : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/bands/without-genre", Handle)
            .WithSummary("Get all bands, without showing their genre");

        public record Response(int Id, string Name);

        private static IResult Handle(IDatabase db)
        {
            try
            {
                var allBands = db.Bands
                    .Select(b => new Response(b.Id, b.Name)) 
                    .ToList();

                if (allBands.Count == 0)
                {
                    return Results.NoContent();
                }

                return Results.Ok(allBands);
            }
            catch (Exception ex)
            {
                return ErrorHandler.HandleError(ex);
            }
        }
    }
}
