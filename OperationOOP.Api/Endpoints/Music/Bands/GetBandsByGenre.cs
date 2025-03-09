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

        private static IResult Handle(string genre, MusicRepository musicRepository)
        {
            try
            {
                if (string.IsNullOrEmpty(genre))
                {
                    return Results.BadRequest("Genre kan inte vara tom.");
                }

                var bands = musicRepository.GetBandsByGenre(genre);

                if (bands == null || bands.Count == 0)
                {
                    return Results.NotFound($"Inga band hittades för genren {genre}.");
                }
                return Results.Ok(bands.Select(b => new Response(b.Id, b.Name, b.Genre)).ToList());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Fel vid hämtning av band: {ex.Message}");
                return Results.Problem("Ett oväntat fel inträffade när vi försökte hämta banden.");
            }
        }
    }
}
