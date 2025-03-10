namespace OperationOOP.Api.Endpoints.NewFolder
{
    public class GetSongCountPerAlbum : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/albums/songcount", Handle)
            .WithSummary("Get song count per album");

        public record Response(int AlbumId, string AlbumName, int SongCount);

        private static IResult Handle(IDatabase db)
        {
            var albumSongCounts = db.Albums
                .Select(a => new Response(a.Id, a.Name, db.Songs.Count(s => s.Album == a.Name)))
                .ToList();

            return albumSongCounts.Any() ? Results.Ok(albumSongCounts) : Results.NoContent();
        }
    }
}
