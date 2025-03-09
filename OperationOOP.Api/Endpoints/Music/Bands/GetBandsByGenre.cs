namespace OperationOOP.Api.Endpoints.Music.Bands
{
    public class GetBandsByGenre : IEndpoint
    {
        private readonly MusicRepository _musicRepository;
        public GetBandsByGenre(MusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/bands/genre/{genre}", Handle)
            .WithSummary("Get bands by genre");

        public record Response(int Id, string Name, string Genre);

        private static List<Response> Handle(string genre, MusicRepository musicRepository)
        {
            var bands = musicRepository.GetBandsByGenre(genre);
            return bands.Select(b => new Response(b.Id, b.Name, b.Genre)).ToList();
        }
    }
}
