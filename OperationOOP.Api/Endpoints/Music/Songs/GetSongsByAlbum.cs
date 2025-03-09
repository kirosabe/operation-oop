namespace OperationOOP.Api.Endpoints.Music
{
    public class GetSongsByAlbum : IEndpoint
    {
        private readonly MusicRepository _musicRepository;

        public GetSongsByAlbum(MusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/songs/album/{album}", Handle)
            .WithSummary("Get songs by album");

        public record Response(int Id, string Name, string Album, string Duration);

        private static IResult Handle(string album, MusicRepository musicRepository)
        {
            var validationResult = Validator.ValidateNotEmpty(album, "Album");
            if (validationResult != null) return validationResult;

            try
            {
                var songs = musicRepository.GetSongsByAlbum(album);

                if (songs == null || songs.Count == 0)
                {
                    return Results.NotFound($"Inga låtar hittades för albumet {album}.");
                }

                return Results.Ok(songs.Select(s => new Response(s.Id, s.Name, s.Album, s.Duration)).ToList());
            }
            catch (Exception ex)
            {
                return ErrorHandler.HandleError(ex);
            }
        }
    }
}
