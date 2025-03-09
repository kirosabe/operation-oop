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

        private static List<Response> Handle(string album, MusicRepository musicRepository)
        {
            var songs = musicRepository.GetSongsByAlbum(album);
            return songs.Select(s => new Response(s.Id, s.Name, s.Album, s.Duration)).ToList();
        }
    }
}
