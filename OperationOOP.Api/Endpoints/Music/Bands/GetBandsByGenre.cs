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
            var validationResult = Validator.ValidateNotEmpty(genre, "Genre");
            if (validationResult != null) return validationResult;

            try
            {
                var bands = musicRepository.GetBandsByGenre(genre);

                if (bands == null || bands.Count == 0)
                {
                    return Results.NotFound($"Inga band hittades för genren {genre}.");
                }

                return Results.Ok(bands.Select(b => new Response(b.Id, b.Name, b.Genre)).ToList());
            }
            catch (Exception ex)
            {
                return ErrorHandler.HandleError(ex);
            }
        }
    }
}
