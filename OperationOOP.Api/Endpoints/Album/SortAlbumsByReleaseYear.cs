namespace OperationOOP.Api.Endpoints.NewFolder
{
    public class SortAlbumsByReleaseYear : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/albums/sorted", Handle)
            .WithSummary("Get all albums sorted by release year");

        public record Response(int Id, string Name, string ReleaseYear);

        private static IResult Handle(IDatabase db)
        {
            var albums = db.Albums
                .OrderBy(a => a.ReleaseYear)
                .Select(a => new Response(a.Id, a.Name, a.ReleaseYear))
                .ToList();

            return albums.Any() ? Results.Ok(albums) : Results.NoContent();
        }
    }
}
